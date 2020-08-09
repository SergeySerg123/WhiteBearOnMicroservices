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
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  public loadBottles() {
    this.httpService.getFullRequest(this.baseUrl + '/api/bottles')
    .pipe(takeUntil(this.unsubscribe$))
    .subscribe((resp) => {
      this.bottles = resp.body as Bottle[];
    } );
  }

  public calcBottles(quantity: number): Bottle[] {
    let bottle = this.bottles.filter( (bottle) => bottle.capacity === quantity );
    
    if (bottle !== null && bottle !== undefined) {
      return  [...bottle];
    }

    let maxCapacityBottle = this.calcMaxCapacityBottle();

    let countBottleWithMaxCapacity = Math.floor(quantity/maxCapacityBottle.capacity);
    let lastBottleCapacity = quantity - (maxCapacityBottle.capacity * countBottleWithMaxCapacity);

    return this.selectBottles(countBottleWithMaxCapacity, maxCapacityBottle.capacity, lastBottleCapacity);
  }

  private calcMaxCapacityBottle(): Bottle {
    return this.bottles.reduce((prev, current) => {
      if (+current.capacity > +prev.capacity) {
        return current;
      } else {
          return prev;
      }
    });
  }

  private selectBottles(countBottleWithMaxCapacity: number, 
    maxCapacityBottle: number, lastBottleCapacity: number): Bottle[] {
    
     let bottles: Bottle[] = [];
    
     for(let i = 0; i < countBottleWithMaxCapacity; i++) {
      bottles.push(
        this.bottles.find( 
          (bottle) => bottle.capacity === maxCapacityBottle)
      );
    }

    
    if (lastBottleCapacity !== 0) {
      bottles.push(
        this.bottles.find( 
          (bottle) => bottle.capacity === lastBottleCapacity)
      );
    }
    
    return bottles;
  }
}
