import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { INewsPage } from '../interfaces/INewsPage';
import { NewsViewModel } from '../viewModels/NewsViewModel';

@Injectable({
  providedIn: 'root'
})
export class NewsService {

  constructor(private httpClient: HttpClient, private router: Router,) { }

  baseUrl = environment.apiEndpoint + 'api/News/';

  getNewsPaged(page: number, size: number): Observable<INewsPage> {
    let params = new HttpParams();

    params = params.append('PageNumber', String(page));
    params = params.append('PageSize', String(size));

    return this.httpClient.get(this.baseUrl + "getNews?" + params).pipe(
      map((newsData: INewsPage) => newsData),
      catchError(err => throwError(err))
    )
  }

  getNewsById(newsId: string): Observable<NewsViewModel> {
    return this.httpClient.get<NewsViewModel>(this.baseUrl + "getNewsById/" + newsId);
  }
}
