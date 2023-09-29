import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountHolderFormComponent } from './account-holder-form.component';

describe('AccountHolderFormComponent', () => {
  let component: AccountHolderFormComponent;
  let fixture: ComponentFixture<AccountHolderFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccountHolderFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccountHolderFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
