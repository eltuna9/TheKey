import React from 'react';
import PropTypes from 'prop-types';
import './mainHeader.scss';

const MainHeader = props => {
  return <h1 className="mainHeader">{props.children}</h1>;
};

MainHeader.propTypes = {
  children: PropTypes.any
};

export default MainHeader;
