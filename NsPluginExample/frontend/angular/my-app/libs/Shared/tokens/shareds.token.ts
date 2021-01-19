import { InjectionToken } from '@angular/core';

export const WINDOW = new InjectionToken('WINDOW', {
  providedIn: 'root',
  factory: () => window
});
export const DOCUMENT = new InjectionToken('DOCUMENT', {
  providedIn: 'root',
  factory: () => window.document
});

