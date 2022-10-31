import { Component, OnInit } from '@angular/core';
import { IPublicCodes } from '../../../@core/interfaces/IPublicCodes';
import { SettingsService } from '../../../@core/services/settings.service';
import { HomeComponent } from '../../pages/home/home.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  home: HomeComponent;
  publicCodes: IPublicCodes[];

  constructor(
    private settingsServices: SettingsService) {
    this.getText();
  }

  ngOnInit(): void {
    this.getText();
  }

  useLanguage(language: string): void {
    this.settingsServices.getPublicCodes(language).subscribe(x => { this.publicCodes = x });
    localStorage.setItem('codes', JSON.stringify(this.publicCodes));
  }

  getText() {
    this.settingsServices.getPublicCodes('al').subscribe(x => { this.publicCodes = x });
    localStorage.setItem('codes', JSON.stringify(this.publicCodes));
  }
}
