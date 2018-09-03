import {SET_SEARCH_RESULTS, SET_SEARCH_PENDING, SET_SEARCH_ERROR} from '../actions/actionTypes';

const initialState = {
  searchResult: null,
  isSearchPending: false,
  hasError: false
};

export default function searchReducer(state = initialState, action) {
  switch (action.type) {
    case SET_SEARCH_RESULTS: {
      return Object.assign({}, state, {searchResult: action.result, isSearchPending: false, hasError:false});
    }
    case SET_SEARCH_PENDING: {
      return Object.assign({}, state, {isSearchPending: action.isPending, hasError: !action.isPending, searchResult:null});
    }
    case SET_SEARCH_ERROR: {
      return Object.assign({}, state, {hasError: action.hasError, isSearchPending: !action.hasError,  searchResult:null});
    }
    default: {
      return state;
    }
  }
}
