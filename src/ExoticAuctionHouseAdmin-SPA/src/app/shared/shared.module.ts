import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { MaterialModule } from './material';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        RouterModule,
        ReactiveFormsModule,
        MaterialModule,
        FormsModule,
        NgxMaterialTimepickerModule
    ],
    exports: [
        CommonModule,
        HttpClientModule,
        RouterModule,
        ReactiveFormsModule,
        MaterialModule,
        FormsModule,
        NgxMaterialTimepickerModule
    ],
    providers: [],
    bootstrap: []
  })
  export class SharedModule { }
