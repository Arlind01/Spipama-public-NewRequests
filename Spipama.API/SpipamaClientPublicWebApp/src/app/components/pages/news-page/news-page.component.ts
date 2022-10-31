import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Observable, Observer } from 'rxjs';
import { map } from 'rxjs/operators';
import { INewsPage } from '../../../@core/interfaces/INewsPage';
import { NewsService } from '../../../@core/services/news.service';
import { NewsViewModel } from '../../../@core/viewModels/NewsViewModel';

@Component({
  selector: 'app-news-page',
  templateUrl: './news-page.component.html',
  styleUrls: ['./news-page.component.scss']
})
export class NewsPageComponent implements OnInit {

  public newsViewModel: NewsViewModel = new NewsViewModel();
  public topNews: INewsPage = null;
  public topThreeNews: INewsPage = null;
  
  id: any;

  constructor(private newsService: NewsService, private activatedRoute: ActivatedRoute, private sanitizer: DomSanitizer) {
    this.id = this.activatedRoute.snapshot.paramMap.get("id");
  }

  ngOnInit(): void {
    this.getNewsById();
    this.getNews();
  }

  getNewsById() {
    this.newsService.getNewsById(this.id).subscribe(res => {
      this.newsViewModel = res;
    })
  }

  getNews() {
    this.newsService.getNewsPaged(1, 3).pipe(
      map((newsData: INewsPage) => {
        this.topNews = newsData;
        for (var i = 0; i < this.topNews.data.length; i++) {
          this.topNews.data[i].imageUrl = this.topNews.data[i].imageUrl.replace(/\\/g, "/");
        }
        this.topNews.data.sort(() => 0.5 - Math.random());
      })
    ).subscribe();
  }
}
