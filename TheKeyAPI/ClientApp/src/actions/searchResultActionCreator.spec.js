import * as actionTypes from './actionTypes';
import * as actions from './searchResultActionCreator';

describe('Action creators test suite', () => {
  it('should create an action to set the search result', () => {
    const result = [];
    const expectedAction = {
      type: actionTypes.SET_SEARCH_RESULTS,
      result
    };
    expect(actions.setSearchResult(result)).toEqual(expectedAction);
  });

  it('should create an action to set the search as pending', () => {
    const isPending = true;
    const expectedAction = {
      type: actionTypes.SET_SEARCH_PENDING,
      isPending
    };
    expect(actions.setSearchPending(isPending)).toEqual(expectedAction);
  });

  it('should create an action to set the search as failed', () => {
    const hasError = true;
    const expectedAction = {
      type: actionTypes.SET_SEARCH_ERROR,
      hasError
    };
    expect(actions.setSearchError(hasError)).toEqual(expectedAction);
  });
});
