var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, ChangeDetectionStrategy, ViewChild, TemplateRef } from '@angular/core';
import { startOfDay, endOfDay, subDays, addDays, endOfMonth, isSameDay, isSameMonth, addHours } from 'date-fns';
import { Subject } from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
const colors = {
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
let CalendarComponent = class CalendarComponent {
    constructor(modal) {
        this.modal = modal;
        this.view = 'month';
        this.viewDate = new Date();
        this.actions = [
            {
                label: '<i class="fa fa-fw fa-pencil"></i>',
                onClick: ({ event }) => {
                    this.handleEvent('Edited', event);
                }
            },
            {
                label: '<i class="fa fa-fw fa-times"></i>',
                onClick: ({ event }) => {
                    this.events = this.events.filter(iEvent => iEvent !== event);
                    this.handleEvent('Deleted', event);
                }
            }
        ];
        this.refresh = new Subject();
        this.events = [
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
        this.activeDayIsOpen = true;
    }
    dayClicked({ date, events }) {
        if (isSameMonth(date, this.viewDate)) {
            if ((isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) ||
                events.length === 0) {
                this.activeDayIsOpen = false;
            }
            else {
                this.activeDayIsOpen = true;
                this.viewDate = date;
            }
        }
    }
    eventTimesChanged({ event, newStart, newEnd }) {
        event.start = newStart;
        event.end = newEnd;
        this.handleEvent('Dropped or resized', event);
        this.refresh.next();
    }
    handleEvent(action, event) {
        this.modalData = { event, action };
        this.modal.open(this.modalContent, { size: 'lg' });
    }
    addEvent() {
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
};
__decorate([
    ViewChild('modalContent'),
    __metadata("design:type", TemplateRef)
], CalendarComponent.prototype, "modalContent", void 0);
CalendarComponent = __decorate([
    Component({
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
    }),
    __metadata("design:paramtypes", [NgbModal])
], CalendarComponent);
export { CalendarComponent };
//# sourceMappingURL=calendar.component.js.map