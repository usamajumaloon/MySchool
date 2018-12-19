import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FetchDataService } from './fetch-data.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {
  public forecasts: WeatherForecast[];

  constructor(private settingService: FetchDataService) {

  }

  ngOnInit() {
    this.getTenantInfo();
  }

  getTenantInfo() {
    this.settingService.fetch().subscribe(result => {
      this.forecasts = result;
    },
      error => {
        
      })
  }
}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
