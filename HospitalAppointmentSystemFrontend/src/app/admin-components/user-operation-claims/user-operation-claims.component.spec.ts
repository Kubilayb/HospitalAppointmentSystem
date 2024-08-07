import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserOperationClaimsComponent } from './user-operation-claims.component';

describe('UserOperationClaimsComponent', () => {
  let component: UserOperationClaimsComponent;
  let fixture: ComponentFixture<UserOperationClaimsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserOperationClaimsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UserOperationClaimsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
