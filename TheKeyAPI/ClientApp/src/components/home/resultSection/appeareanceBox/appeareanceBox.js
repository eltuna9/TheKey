import React, {Component} from 'react';
import {addOrdordernalSuffix} from '../../../../helpers/formatterHelper';
import PropTypes from 'prop-types';
import './appeareanceBox.scss';

const AppeareanceBox = props => {
  return (
    <div className="row appeareance-box">
      <div className="col-xs-12">
        <span className="appeareance-box__number">{addOrdordernalSuffix(props.appearenceOrder)}: </span>
        <span className="appeareance-box__linkText">{props.linkTitle}</span>
      </div>
    </div>
  );
};

AppeareanceBox.propTypes = {
  appearenceOrder: PropTypes.number.isRequired,
  linkTitle: PropTypes.string.isRequired
};

export default AppeareanceBox;
