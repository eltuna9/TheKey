import {SET_SEARCH_RESULTS, SET_SEARCH_PENDING, SET_SEARCH_ERROR} from './actionTypes';

export function setSearchResult(result) {
  return {type: SET_SEARCH_RESULTS, result};
}

export function setSearchPending(isPending) {
  return {type: SET_SEARCH_PENDING, isPending};
}

export function setSearchError(hasError) {
  return {type: SET_SEARCH_ERROR, hasError};
}
