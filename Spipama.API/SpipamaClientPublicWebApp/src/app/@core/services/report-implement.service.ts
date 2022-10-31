import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { IReportImplementation } from "../interfaces/IReportImplementation";
import { ReportImplementationViewModel } from '../viewModels/ReportImplementationViewModel';


@Injectable({
  providedIn: 'root'
})
export class ReportImplemenationService {

  constructor(private httpClient: HttpClient, private router: Router,) { }

  baseUrl = environment.apiEndpoint + 'api/Report-implement/';

  getReportPaged(page: number, size: number): Observable<IReportImplementation> {
    let params = new HttpParams();

    params = params.append('PageNumber', String(page));
    params = params.append('PageSize', String(size));

    return this.httpClient.get(this.baseUrl + "getReport?" + params).pipe(
      map((newsData: IReportImplementation) => newsData),
      catchError(err => throwError(err))
    )
  }

  getReportById(newsId: string): Observable<ReportImplementationViewModel> {
    return this.httpClient.get<ReportImplementationViewModel>(this.baseUrl + "getNewsById/" + newsId);
  }
}
