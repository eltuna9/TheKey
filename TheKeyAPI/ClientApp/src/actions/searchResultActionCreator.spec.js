import * as actionTypes from './actionTypes';
import * as actions from './searchResultActionCreator';

describe('Action creators test suite', () => {
  it('should create an action to set the search result', () => {
    const results = [];
    const expectedAction = {
      type: actionTypes.SET_SEARCH_RESULTS,
      results
    };
    expect(actions.setSearchResult(resultsnpm)).toEqual(expectedAction);
  });
});
