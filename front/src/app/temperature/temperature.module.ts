import { NgModule } from '@angular/core';
import { ConverterComponent } from './converter/converter.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';  
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [
      ConverterComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
      RouterModule.forChild([
        { path: 'temperature', component: ConverterComponent },
      ]),
    ]
  })
  export class TemperatureModule { }
  


