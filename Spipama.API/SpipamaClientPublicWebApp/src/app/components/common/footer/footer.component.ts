import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { IPublicCodes } from '../../../@core/interfaces/IPublicCodes';
import { DataService } from '../../../@core/services/data.service';
import { SettingsService } from '../../../@core/services/settings.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  @Input() someInput: IPublicCodes[];

  constructor(private settingsService: SettingsService)
  {
  }

  date: string = "2021"
  isDataAvaible: boolean = false;

  ngOnInit(): void {
    this.date = new Date().getFullYear().toString();
    this.setText();
  }

  setText() {
    var codes = localStorage.getItem('codes');
    if (this.someInput == null) {
      this.settingsService.getPublicCodes('al').subscribe(x => { this.someInput = x; localStorage.setItem('codes', JSON.stringify(x)); this.isDataAvaible = true });
    }
    else {
      this.someInput = <IPublicCodes[]>JSON.parse(codes);
      this.isDataAvaible = true;
    }
  }

  getTextId(id): string {
    return this.someInput.find(x => x.id == id).name;
  }

}
