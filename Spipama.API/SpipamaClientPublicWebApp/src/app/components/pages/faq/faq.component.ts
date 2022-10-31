import { Component, OnInit } from '@angular/core';
import { IPublicCodes } from '../../../@core/interfaces/IPublicCodes';

@Component({
  selector: 'app-faq',
  templateUrl: './faq.component.html',
  styleUrls: ['./faq.component.scss']
})
export class FaqComponent implements OnInit {

  codes: IPublicCodes[] = null;

  constructor() { }

  ngOnInit(): void {
  }

  getTextId(id): string {
    return this.codes.find(x => x.id == id).name;
  }
}
