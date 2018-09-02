import {SET_SEARCH_RESULTS, SET_SEARCH_PENDING} from '../actions/actionTypes';

const initialState = {
  searchResult: null,
  isSearchPending: false,
  hasError: false
};

export default function searchReducer(state = initialState, action) {
  switch (action.type) {
    case SET_SEARCH_RESULTS: {
      return Object.assign({}, state, {searchResult: action.result});
    }
    case SET_SEARCH_PENDING: {
      return Object.assign({}, state, {isSearchPending: action.isPending});
    }
    default: {
      return state;
    }
  }
}
