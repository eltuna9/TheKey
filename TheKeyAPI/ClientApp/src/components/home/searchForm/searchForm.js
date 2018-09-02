import React, {Component} from 'react';
import PropTypes from 'prop-types';

export default class SearchForm extends Component {
  constructor(props) {
    super(props);
    this.state = {
      keywords: '',
      url: ''
    };
  }
  render() {
    return (
      <form onSubmit={this.handleFormSubmit.bind(this)} className="home__search-form">
        <div className="row">
          <div className="col-md-5 col-xs-12">
            <h4 className="form-text">Your site url</h4>
            <input
              type="text"
              className="form-control"
              onChange={this.handleUrlChange.bind(this)}
              type="url"
              required
            />
          </div>
          <div className="col-md-5 col-xs-12">
            <h4 className="form-text">Your site url</h4>
            <input
              type="text"
              className="form-control"
              onChange={this.handleUrlChange.bind(this)}
              type="text"
              required
            />
          </div>
          <div className="col-md-2 col-xs-12">
            <input type="button" value="Show Appeareances" className="btn-primary" />
          </div>
        </div>
      </form>
    );
  }

  handleFormSubmit() {}
}
