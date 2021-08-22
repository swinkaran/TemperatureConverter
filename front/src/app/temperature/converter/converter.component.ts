import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ITemperature } from '../temperature';
import { TemperatureService } from '../temperatureService';

@Component({
  selector: 'pm-converter',
  templateUrl: './converter.component.html',
  styleUrls: ['./converter.component.css']
})
export class ConverterComponent implements OnInit {
  pageTitle: string = 'Temperature Converter Application';
  sub!: Subscription;  
  errorMessage = '';
  temperatures: ITemperature[] = [];  
  
  selectedFromOption: string = 'Celsius';
  selectedToOption: string = 'Celsius';
  temperatureInput:number = 0;
  temperatureOutput:string ='';

  constructor(private temperatureService: TemperatureService) { 
  }

  ngOnInit(): void {
    console.log('reading the data');

    //
    this.sub = this.temperatureService.gettemperatures().subscribe({
      next: temperatures => {
        this.temperatures = temperatures;
      },
      error: err  => this.errorMessage = err
    });

    this.temperatures.forEach(function (value) {
      console.log(value['temperatureType']);

      console.log('Complete data');
  });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
  
  convertMetric()
  {
    this.sub = this.temperatureService.gettemperatureByMetric(this.selectedFromOption, this.temperatureInput).subscribe({
      next: resp => {
        this.temperatureOutput = ''+ this.temperatureInput + ' ' + this.selectedFromOption + ' = ' 
        + resp?.find(a => a.temperatureType.toLocaleLowerCase() == this.selectedToOption.toLowerCase())?.temperatureValue 
        + ' ' +this.selectedToOption
      },
      error: err  => this.errorMessage = err
    });
  }
}
