import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from 'app/core/services/base.service';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';

@Injectable()
export class TableService extends BaseService {

  private studentEndPoint = `${this.baseApiEndPoint}Student`;

  constructor(private http: HttpClient) {
    super();
  }

  getStudents(){
    return this.http.get(`${this.studentEndPoint}`).map(res => res).catch(this.errorHandler)
  }
}
