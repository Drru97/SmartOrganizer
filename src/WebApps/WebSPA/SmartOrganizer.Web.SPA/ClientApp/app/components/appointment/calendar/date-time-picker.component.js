var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { ChangeDetectorRef, Component, forwardRef, Input } from '@angular/core';
import { getSeconds, getMinutes, getHours, getDate, getMonth, getYear, setSeconds, setMinutes, setHours, setDate, setMonth, setYear } from 'date-fns';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
export const DATE_TIME_PICKER_CONTROL_VALUE_ACCESSOR = {
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => DateTimePickerComponent),
    multi: true
};
let DateTimePickerComponent = class DateTimePickerComponent {
    constructor(cdr) {
        this.cdr = cdr;
        this.onChangeCallback = () => { };
    }
    writeValue(date) {
        this.date = date;
        this.dateStruct = {
            day: getDate(date),
            month: getMonth(date) + 1,
            year: getYear(date)
        };
        this.timeStruct = {
            second: getSeconds(date),
            minute: getMinutes(date),
            hour: getHours(date)
        };
        this.cdr.detectChanges();
    }
    registerOnChange(fn) {
        this.onChangeCallback = fn;
    }
    registerOnTouched(fn) { }
    updateDate() {
        const newDate = setYear(setMonth(setDate(this.date, this.dateStruct.day), this.dateStruct.month - 1), this.dateStruct.year);
        this.writeValue(newDate);
        this.onChangeCallback(newDate);
    }
    updateTime() {
        const newDate = setHours(setMinutes(setSeconds(this.date, this.timeStruct.second), this.timeStruct.minute), this.timeStruct.hour);
        this.writeValue(newDate);
        this.onChangeCallback(newDate);
    }
};
__decorate([
    Input(),
    __metadata("design:type", String)
], DateTimePickerComponent.prototype, "placeholder", void 0);
DateTimePickerComponent = __decorate([
    Component({
        selector: 'mwl-demo-utils-date-time-picker',
        template: `
    <form class="form-inline">
      <div class="form-group">
        <div class="input-group">
          <input
            readonly
            class="form-control"
            [placeholder]="placeholder"
            name="date"
            [(ngModel)]="dateStruct"
            (ngModelChange)="updateDate()"
            ngbDatepicker
            #datePicker="ngbDatepicker">
            <div class="input-group-append" (click)="datePicker.toggle()" >
              <span class="input-group-text"><i class="fa fa-calendar"></i></span>
            </div>
        </div>
      </div>
    </form>
    <ngb-timepicker
      [(ngModel)]="timeStruct"
      (ngModelChange)="updateTime()"
      [meridian]="true">
    </ngb-timepicker>
  `,
        styles: [
            `
    .form-group {
      width: 100%;
    }
  `
        ],
        providers: [DATE_TIME_PICKER_CONTROL_VALUE_ACCESSOR]
    }),
    __metadata("design:paramtypes", [ChangeDetectorRef])
], DateTimePickerComponent);
export { DateTimePickerComponent };
//# sourceMappingURL=date-time-picker.component.js.map