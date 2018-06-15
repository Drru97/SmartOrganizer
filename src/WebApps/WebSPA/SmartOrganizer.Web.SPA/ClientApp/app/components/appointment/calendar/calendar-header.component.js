var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input, Output, EventEmitter } from '@angular/core';
let CalendarHeaderComponent = class CalendarHeaderComponent {
    constructor() {
        this.locale = 'en';
        this.viewChange = new EventEmitter();
        this.viewDateChange = new EventEmitter();
    }
};
__decorate([
    Input(),
    __metadata("design:type", String)
], CalendarHeaderComponent.prototype, "view", void 0);
__decorate([
    Input(),
    __metadata("design:type", Date)
], CalendarHeaderComponent.prototype, "viewDate", void 0);
__decorate([
    Input(),
    __metadata("design:type", String)
], CalendarHeaderComponent.prototype, "locale", void 0);
__decorate([
    Output(),
    __metadata("design:type", EventEmitter)
], CalendarHeaderComponent.prototype, "viewChange", void 0);
__decorate([
    Output(),
    __metadata("design:type", EventEmitter)
], CalendarHeaderComponent.prototype, "viewDateChange", void 0);
CalendarHeaderComponent = __decorate([
    Component({
        selector: 'mwl-demo-utils-calendar-header',
        template: `
    <div class="row text-center">
      <div class="col-md-4">
        <div class="btn-group">
          <div
            class="btn btn-primary"
            mwlCalendarPreviousView
            [view]="view"
            [(viewDate)]="viewDate"
            (viewDateChange)="viewDateChange.next(viewDate)">
            Previous
          </div>
          <div
            class="btn btn-outline-secondary"
            mwlCalendarToday
            [(viewDate)]="viewDate"
            (viewDateChange)="viewDateChange.next(viewDate)">
            Today
          </div>
          <div
            class="btn btn-primary"
            mwlCalendarNextView
            [view]="view"
            [(viewDate)]="viewDate"
            (viewDateChange)="viewDateChange.next(viewDate)">
            Next
          </div>
        </div>
      </div>
      <div class="col-md-4">
        <h3>{{ viewDate | calendarDate:(view + 'ViewTitle'):locale }}</h3>
      </div>
      <div class="col-md-4">
        <div class="btn-group">
          <div
            class="btn btn-primary"
            (click)="viewChange.emit('month')"
            [class.active]="view === 'month'">
            Month
          </div>
          <div
            class="btn btn-primary"
            (click)="viewChange.emit('week')"
            [class.active]="view === 'week'">
            Week
          </div>
          <div
            class="btn btn-primary"
            (click)="viewChange.emit('day')"
            [class.active]="view === 'day'">
            Day
          </div>
        </div>
      </div>
    </div>
    <br>
  `
    })
], CalendarHeaderComponent);
export { CalendarHeaderComponent };
//# sourceMappingURL=calendar-header.component.js.map