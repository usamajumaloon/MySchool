import { Injectable } from '@angular/core';
import { BaseService } from '../modules/core/services/base.service';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class FetchDataService extends BaseService {

  private memberEndPoint = `${this.baseApiEndPoint}SampleData/WeatherForecasts`;

  constructor(private http: HttpClient) {
    super(); 
  }

  fetch() {
    return this.http.get(`${this.memberEndPoint}`)
      .map((response) => response)
      .catch(this.errorHandler)
  }
}
