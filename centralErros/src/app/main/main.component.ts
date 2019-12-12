import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator } from '@angular/material';
import { Router } from '@angular/router';
import { LogService } from '../services/log.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})

export class MainComponent implements OnInit {

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  hasData;

  filter = {
    environment: '',
    order: '',
    search: '',
    searchValue: ''
  }

  dataSource;
  displayedColumns: string[] = ['level', 'description', 'origin', 'date', 'frequency', 'actions'];

  ngOnInit(): void {
    this.getLogs();
  }

  getLogs() {
        this.logService.getLogs().toPromise().then((data) => {
        this.dataSource = new MatTableDataSource(data);
        this.dataSource.paginator = this.paginator;
        this.hasData =  data.length > 0;
    })
  }

  archive(ev, log) {
    this.logService.updateLog(ev,log).toPromise().then( () => {
      this.getLogs();
    });
  }

  unarchive(ev, log) {
    this.logService.updateLog(ev,log).toPromise().then( () => {
      this.getLogs();
    });
  }

  delete(ev) {
    this.logService.deleteLog(ev).toPromise().then( () => {
      this.getLogs();
    });
  }

  show(ev) {
    this.router.navigate(['/description', ev]);
  }

  onFilter() {
    this.logService.getLogsFilter(this.filter).toPromise().then((data) => {
      console.table(data)
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.paginator = this.paginator;
      this.hasData =  data.length > 0;
  })
    console.table(this.filter)
  }

  constructor(public router : Router, public logService : LogService) { }
}
