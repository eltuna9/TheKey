export const addOrdordernalSuffix = order => {
  var lastDigit = order % 10,
    firsDigit = order % 100;
  if (lastDigit == 1 && firsDigit != 11) {
    return order + 'st';
  }
  if (lastDigit == 2 && firsDigit != 12) {
    return order + 'nd';
  }
  if (lastDigit == 3 && firsDigit != 13) {
    return order + 'rd';
  }
  return order + 'th';
};
