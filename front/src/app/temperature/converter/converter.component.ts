import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ITemperature } from '../temperature';
import { TemperatureService } from '../temperatureService';

@Component({
  selector: 'pm-converter',
  templateUrl: './converter.component.html',
  styleUrls: ['./converter.component.css']
})
export class ConverterComponent implements OnInit {
  pageTitle: string = 'Temperature converter';
  sub!: Subscription;  
  errorMessage = '';
  temperatures: ITemperature[] = [];  
  selectedFromOption: string = 'Celsius';
  selectedToOption: string = 'Celsius';
  temperatureInput:string='';
  temperatureOutput:string='';

  modifiedText:string='';

  constructor(private temperatureService: TemperatureService) { }

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
    console.log('Converting '+ this.temperatureInput +' from ' + this.selectedFromOption + ' to ' + this.selectedToOption + ' ');
    //call api
    //this.customFunction(val);
    
  }

  onTemperatureSElected(val : any)
  {
    //call api
    this.customFunction(val);
    
  }

  customFunction(val: any)
  {
    this.modifiedText = 'The value seleced is '+ val + '';
  }
}
