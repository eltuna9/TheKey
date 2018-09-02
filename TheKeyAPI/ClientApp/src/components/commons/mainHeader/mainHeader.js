import React from 'react';
import PropTypes from 'prop-types';
import './mainHeader.scss';

const MainHeader = props => {
  return <h1 className="mainHeader">{props.text}</h1>;
};

MainHeader.propTypes = {
  text: PropTypes.string.isRequired
};

export default MainHeader;
