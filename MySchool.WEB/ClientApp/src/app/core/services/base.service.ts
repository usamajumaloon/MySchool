import { HttpHeaders } from '@angular/common/http';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import { environment } from 'environments/environment';

export abstract class BaseService {

  protected baseApiEndPoint = environment.apiEndPoint;
  
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

  protected httpOptionsFileType = {
    headers: new HttpHeaders({
      'enctype': 'multipart/form-data',
    })
  };

  constructor() {
  }

  protected extractData(res: Response) {
    return res.json
  }


  protected errorHandler(error: Response | any) {
    // In a real world app, we might use a remote logging infrastructure
  
    let errMsg: string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body.error || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.error.result ? error.error.result  : error.statusText;
    }
    console.error(errMsg);
    return Observable.throw(errMsg);
  }
}
