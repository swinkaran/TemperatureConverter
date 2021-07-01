import { NgModule } from '@angular/core';
import { ConverterComponent } from './converter/converter.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';  

@NgModule({
    declarations: [
      ConverterComponent
    ],
    imports: [
        CommonModule,
      RouterModule.forChild([
        { path: 'temperature', component: ConverterComponent },
      ]),
    ]
  })
  export class TemperatureModule { }
  


