import { Injectable, OnInit, OnDestroy } from '@angular/core';
import { Bottle } from '../models/bottle/bottle';
import { HttpInternalService } from './http-internal.service';
import { environment } from 'src/environments/environment';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BottleService implements OnInit, OnDestroy {
  private baseUrl = environment.catalogApiUrl;
  private bottles: Bottle[] = null;

  private unsubscribe$ = new Subject<void>();

  constructor(private httpService: HttpInternalService) { }
  
  ngOnInit(): void {
    this.httpService.getFullRequest(this.baseUrl + '/api/bottles')
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((resp) => this.bottles = resp.body as Bottle[]);
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
