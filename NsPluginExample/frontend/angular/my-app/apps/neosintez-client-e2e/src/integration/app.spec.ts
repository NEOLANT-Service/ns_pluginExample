import { getGreeting } from '../support/app.po';

describe('neosintez-client', () => {
  beforeEach(() => cy.visit('/'));

  it('should display welcome message', () => {
    getGreeting().contains('Welcome to neosintez-client!');
  });
});
