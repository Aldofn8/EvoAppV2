import { createActionGroup, props } from '@ngrx/store';


export const loadCustomer = createActionGroup({
source: 'Customer',
  events: {
    'Add Customer': props<{ customerId: number }>(),
    'Remove Customer': props<{ customerId: number }>(),
  },
}); 

export const CustomerApiActions = createActionGroup({
  source: 'Customer API',
  events: {
    'Retrieved Customer List': props<{ customer: ReadonlyArray<any> }>(),
  },
});