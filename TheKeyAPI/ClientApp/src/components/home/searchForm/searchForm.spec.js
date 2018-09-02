import React from 'react';
import {shallow} from 'enzyme';
import {SearchForm} from './searchForm';

it('Uptades the state when the user changes the inputs', () => {
  const handleChangeSpy = sinon.spy();
  const event = {target: {name: 'pollName', value: 'spam'}};
  const wrap = shallow(<SearchForm />);

  wrap.getElement();

  wrap.ref('pollName').simulate('change', event);
  expect(handleChangeSpy.calledOnce).to.equal(true);
});
