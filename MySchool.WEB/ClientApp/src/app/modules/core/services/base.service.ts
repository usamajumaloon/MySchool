import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { Response } from '@angular/http';
import { HttpHeaders } from '@angular/common/http';

@Injectable()
export abstract class BaseService {

  protected baseApiEndPoint = environment.apiEndPoint;

  constructor() { }

  protected httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };

  protected httpOptionsFormType = {
    headers: new HttpHeaders({
      'Content-Type': 'application/x-www-form-urlencoded',
    })
  };

  protected errorHandler(error: Response | any) {
    // In a real world app, we might use a remote logging infrastructure
    let errMsg: string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body.error || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.statusText ? error.error.result  : error.error.error.message ? error.error.error.message :  error.error.result ;
    }
    console.error(errMsg);
    return Observable.throw(errMsg);
  }

}
