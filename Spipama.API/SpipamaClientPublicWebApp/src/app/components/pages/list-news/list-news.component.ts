import { Component, OnInit } from '@angular/core';
import { MatPaginatorIntl, PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { map } from 'rxjs/operators';
import { INewsPage } from '../../../@core/interfaces/INewsPage';
import { NewsService } from '../../../@core/services/news.service';

@Component({
  selector: 'app-list-news',
  templateUrl: './list-news.component.html',
  styleUrls: ['./list-news.component.scss']
})
export class ListNewsComponent implements OnInit {
  dataSource: INewsPage = null;

  constructor(private router: Router, private newsService: NewsService, public _MatPaginatorIntl: MatPaginatorIntl, private translate: TranslateService,) {
    this.getNews();
    translate.setDefaultLang('al');
  }

  ngOnInit(): void {
    this._MatPaginatorIntl.itemsPerPageLabel = this.translate['newsHome.newsPerPage'];
  }

  useLanguage(language: string): void {
    this.translate.use(language);
  }

  getNews() {
    this.newsService.getNewsPaged(1, 9).pipe(
      map((newsData: INewsPage) => {
        this.dataSource = newsData;
        for (var i = 0; i < this.dataSource.data.length; i++) {
          this.dataSource.data[i].imageUrl = this.dataSource.data[i].imageUrl.replace(/\\/g, "/");
        }
      })
    ).subscribe();
  }

  onPaginateChange(event: PageEvent) {
    let page = event.pageIndex;
    let size = event.pageSize;

    page = page + 1;
    this.newsService.getNewsPaged(page, size).pipe(
      map((newsData: INewsPage) => {
        this.dataSource = newsData;
        for (var i = 0; i < this.dataSource.data.length; i++) {
          this.dataSource.data[i].imageUrl = this.dataSource.data[i].imageUrl.replace(/\\/g, "/");
        }
      })
    ).subscribe();
  }

  routeToNews(id) {
    this.router.navigate(['/news/' + id]);
  }

  getInnerText(el) {
    return el.innerText;
  }
}
