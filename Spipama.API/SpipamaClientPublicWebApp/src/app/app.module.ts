import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/common/header/header.component';
import { FooterComponent } from './components/common/footer/footer.component';
import { HomeComponent } from './components/pages/home/home.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HighchartsChartModule } from 'highcharts-angular';
import { ListNewsComponent } from './components/pages/list-news/list-news.component';
import { NewsPageComponent } from './components/pages/news-page/news-page.component';
import { RouterModule } from '@angular/router';
import { MatPaginatorModule } from '@angular/material/paginator';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { NgxCaptchaModule } from 'ngx-captcha';
import { FaqComponent } from './components/pages/faq/faq.component';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { ReportImplementComponent } from './components/pages/report-implement/report-implement.component';
import { DataService } from './@core/services/data.service';


export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    ListNewsComponent,
    NewsPageComponent,
    FaqComponent,
    ReportImplementComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatSelectModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HighchartsChartModule,
    RouterModule,
    MatPaginatorModule,
    NgxCaptchaModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
    AccordionModule.forRoot()
  ],
  exports: [
    RouterModule
  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
