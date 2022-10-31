import { NgModule } from '@angular/core';
import { Routes, RouterModule, ExtraOptions } from '@angular/router';

import { HeaderComponent } from './components/common/header/header.component';
import { FooterComponent } from './components/common/footer/footer.component';
import { HomeComponent } from './components/pages/home/home.component';
import { ListNewsComponent } from './components/pages/list-news/list-news.component';
import { NewsPageComponent } from './components/pages/news-page/news-page.component';
import { ReportImplementComponent } from './components/pages/report-implement/report-implement.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'news/:id', component: NewsPageComponent },
  { path: 'list-news', component: ListNewsComponent },
  { path: 'report-implement', component: ReportImplementComponent },
  
];

const config: ExtraOptions = {
  useHash: false,
  scrollPositionRestoration: 'enabled',
};

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    scrollPositionRestoration: 'enabled'
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
