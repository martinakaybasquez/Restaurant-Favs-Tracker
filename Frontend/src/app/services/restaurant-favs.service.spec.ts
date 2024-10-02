import { TestBed } from '@angular/core/testing';

import { RestaurantFavsService } from './restaurant-favs.service';

describe('RestaurantFavsService', () => {
  let service: RestaurantFavsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RestaurantFavsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
