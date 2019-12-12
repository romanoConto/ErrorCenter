import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export class log {
  id: number;
  description: string;
  origin: string;
  level: string;
  log: string;
  environment: string;
  frequency: number;
  date: string;
  isArquived: boolean;
}

const apiUrl = (window.location.origin + '/api/log').replace("4200", "60443");
//const apiUrl = 'http://localhost:60443/api/log';



@Injectable({
  providedIn: 'root'
})
export class LogService {

  constructor(private http: HttpClient) { }

  getLogs(): Observable<any> {
    return this.http.get(apiUrl);
  }

  getLogsFilter(filter): Observable<any> {
    return this.http.post(apiUrl, filter);
  }

  getLog(id: number) {
    const url = `${apiUrl}/${id}`;
    return this.http.get(url).toPromise();
  }

  addLog(log): Observable<log> {
    return this.http.post<log>(apiUrl, log);
  }

  updateLog(id, log): Observable<any> {
    const url = `${apiUrl}/save`;
    return this.http.put(url, log);
  }

  deleteLog(id): Observable<log> {
    const url = `${apiUrl}/${id}`;
    return this.http.delete<log>(url);
  }

}
