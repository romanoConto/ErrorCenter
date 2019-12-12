import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LogService } from '../services/log.service';

@Component({
  selector: 'app-description',
  templateUrl: './description.component.html',
  styleUrls: ['./description.component.css']
})
export class DescriptionComponent implements OnInit {

  id;
  log;
  private sub: any;

  constructor(public logService: LogService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
	  this.id = +params['id'];
	})
    this.logInfo();
  }

  logInfo() {
	this.logService.getLog(this.id).then((data) => { this.log = data; console.table(data) })
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
