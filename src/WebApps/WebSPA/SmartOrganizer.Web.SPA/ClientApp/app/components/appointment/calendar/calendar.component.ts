import {
    Component,
    ChangeDetectionStrategy,
    ViewChild,
    TemplateRef
} from '@angular/core';
import {
    startOfDay,
    endOfDay,
    subDays,
    addDays,
    endOfMonth,
    isSameDay,
    isSameMonth,
    addHours
} from 'date-fns';
import { Subject } from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {
    CalendarEvent,
    CalendarEventAction,
    CalendarEventTimesChangedEvent
} from 'angular-calendar';

import { CalendarHeaderComponent } from './calendar-header.component';
import { DateTimePickerComponent } from './date-time-picker.component';

const colors: any = {
    red: {
        primary: '#ad2121',
        secondary: '#FAE3E3'
    },
    blue: {
        primary: '#1e90ff',
        secondary: '#D1E8FF'
    },
    yellow: {
        primary: '#e3bc08',
        secondary: '#FDF1BA'
    }
};

@Component({
    selector: 'calendar-component',
    changeDetection: ChangeDetectionStrategy.OnPush,
    template: `<ng-template #modalContent let-close="close">
  <div class="modal-header">
    <h5 class="modal-title">Event action occurred</h5>
    <button type="button" class="close" (click)="close()">
      <span aria-hidden="true">&times;</span>
    </button>
  </div>
  <div class="modal-body">
    <div>
      Action:
      <pre>{{ modalData?.action }}</pre>
    </div>
    <div>
      Event:
      <pre>{{ modalData?.event | json }}</pre>
    </div>
  </div>
  <div class="modal-footer">
    <button type="button" class="btn btn-outline-secondary" (click)="close()">OK</button>
  </div>
</ng-template>

<div class="row text-center">
  <div class="col-md-4">
    <div class="btn-group">
      <div
        class="btn btn-primary"
        mwlCalendarPreviousView
        [view]="view"
        [(viewDate)]="viewDate"
        (viewDateChange)="activeDayIsOpen = false">
        Previous
      </div>
      <div
        class="btn btn-outline-secondary"
        mwlCalendarToday
        [(viewDate)]="viewDate">
        Today
      </div>
      <div
        class="btn btn-primary"
        mwlCalendarNextView
        [view]="view"
        [(viewDate)]="viewDate"
        (viewDateChange)="activeDayIsOpen = false">
        Next
      </div>
    </div>
  </div>
  <div class="col-md-4">
    <h3>{{ viewDate | calendarDate:(view + 'ViewTitle'):'en' }}</h3>
  </div>
  <div class="col-md-4">
    <div class="btn-group">
      <div
        class="btn btn-primary"
        (click)="view = 'month'"
        [class.active]="view === 'month'">
        Month
      </div>
      <div
        class="btn btn-primary"
        (click)="view = 'week'"
        [class.active]="view === 'week'">
        Week
      </div>
      <div
        class="btn btn-primary"
        (click)="view = 'day'"
        [class.active]="view === 'day'">
        Day
      </div>
    </div>
  </div>
</div>
<br>
<div [ngSwitch]="view">
  <mwl-calendar-month-view
    *ngSwitchCase="'month'"
    [viewDate]="viewDate"
    [events]="events"
    [refresh]="refresh"
    [activeDayIsOpen]="activeDayIsOpen"
    (dayClicked)="dayClicked($event.day)"
    (eventClicked)="handleEvent('Clicked', $event.event)"
    (eventTimesChanged)="eventTimesChanged($event)">
  </mwl-calendar-month-view>
  <mwl-calendar-week-view
    *ngSwitchCase="'week'"
    [viewDate]="viewDate"
    [events]="events"
    [refresh]="refresh"
    (eventClicked)="handleEvent('Clicked', $event.event)"
    (eventTimesChanged)="eventTimesChanged($event)">
  </mwl-calendar-week-view>
  <mwl-calendar-day-view
    *ngSwitchCase="'day'"
    [viewDate]="viewDate"
    [events]="events"
    [refresh]="refresh"
    (eventClicked)="handleEvent('Clicked', $event.event)"
    (eventTimesChanged)="eventTimesChanged($event)">
  </mwl-calendar-day-view>
</div>

<br><br><br>

<h3>
  Edit events
  <button
    class="btn btn-primary pull-right"
    (click)="addEvent()">
    Add new
  </button>
  <div class="clearfix"></div>
</h3>

<table class="table table-bordered">

  <thead>
    <tr>
      <th>Title</th>
      <th>Primary color</th>
      <th>Secondary color</th>
      <th>Starts at</th>
      <th>Ends at</th>
      <th>Remove</th>
    </tr>
  </thead>

  <tbody>
    <tr *ngFor="let event of events; let index = index">
      <td>
        <input
          type="text"
          class="form-control"
          [(ngModel)]="event.title"
          (keyup)="refresh.next()">
      </td>
      <td>
        <input
          type="color"
          [(ngModel)]="event.color.primary"
          (change)="refresh.next()">
      </td>
      <td>
        <input
          type="color"
          [(ngModel)]="event.color.secondary"
          (change)="refresh.next()">
      </td>
      <td>
        <mwl-demo-utils-date-time-picker
          [(ngModel)]="event.start"
          (ngModelChange)="refresh.next()"
          placeholder="Not set">
        </mwl-demo-utils-date-time-picker>
      </td>
      <td>
        <mwl-demo-utils-date-time-picker
          [(ngModel)]="event.end"
          (ngModelChange)="refresh.next()"
          placeholder="Not set">
        </mwl-demo-utils-date-time-picker>
      </td>
      <td>
        <button
          class="btn btn-danger"
          (click)="events.splice(index, 1); refresh.next()">
          Delete
        </button>
      </td>
    </tr>
  </tbody>

</table>`
})
export class CalendarComponent {
    @ViewChild('modalContent')
    modalContent: TemplateRef<any>;

    view: string = 'month';

    viewDate: Date = new Date();

    modalData: {
        action: string;
        event: CalendarEvent;
    };

    actions: CalendarEventAction[] = [
        {
            label: '<i class="fa fa-fw fa-pencil"></i>',
            onClick: ({ event }: { event: CalendarEvent }): void => {
                this.handleEvent('Edited', event);
            }
        },
        {
            label: '<i class="fa fa-fw fa-times"></i>',
            onClick: ({ event }: { event: CalendarEvent }): void => {
                this.events = this.events.filter(iEvent => iEvent !== event);
                this.handleEvent('Deleted', event);
            }
        }
    ];

    refresh: Subject<any> = new Subject();

    events: CalendarEvent[] = [
        {
            start: subDays(startOfDay(new Date()), 1),
            end: addDays(new Date(), 1),
            title: 'A 3 day event',
            color: colors.red,
            actions: this.actions
        },
        {
            start: startOfDay(new Date()),
            title: 'An event with no end date',
            color: colors.yellow,
            actions: this.actions
        },
        {
            start: subDays(endOfMonth(new Date()), 3),
            end: addDays(endOfMonth(new Date()), 3),
            title: 'A long event that spans 2 months',
            color: colors.blue
        },
        {
            start: addHours(startOfDay(new Date()), 2),
            end: new Date(),
            title: 'A draggable and resizable event',
            color: colors.yellow,
            actions: this.actions,
            resizable: {
                beforeStart: true,
                afterEnd: true
            },
            draggable: true
        }
    ];

    activeDayIsOpen: boolean = true;

    constructor(private modal: NgbModal) { }

    dayClicked({ date, events }: { date: Date; events: CalendarEvent[] }): void {
        if (isSameMonth(date, this.viewDate)) {
            if (
                (isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) ||
                events.length === 0
            ) {
                this.activeDayIsOpen = false;
            } else {
                this.activeDayIsOpen = true;
                this.viewDate = date;
            }
        }
    }

    eventTimesChanged({
        event,
        newStart,
        newEnd
    }: CalendarEventTimesChangedEvent): void {
        event.start = newStart;
        event.end = newEnd;
        this.handleEvent('Dropped or resized', event);
        this.refresh.next();
    }

    handleEvent(action: string, event: CalendarEvent): void {
        this.modalData = { event, action };
        this.modal.open(this.modalContent, { size: 'lg' });
    }

    addEvent(): void {
        this.events.push({
            title: 'New event',
            start: startOfDay(new Date()),
            end: endOfDay(new Date()),
            color: colors.red,
            draggable: true,
            resizable: {
                beforeStart: true,
                afterEnd: true
            }
        });
        this.refresh.next();
    }
}
