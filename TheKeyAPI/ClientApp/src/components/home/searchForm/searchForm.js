import React, {Component} from 'react';
import PropTypes from 'prop-types';
import * as searchActions from '../../../actions/searchResultActionCreator';
import {connect} from 'react-redux';
import axios from 'axios';
import './searchForm.scss';

class SearchForm extends Component {
  constructor(props) {
    super(props);
    this.state = {
      keywords: 'online title search',
      url: 'www.infotrack.com.au',
      isPending: false
    };
  }
  render() {
    return (
      <div className="container">
        <div className="row search-form">
          <form onSubmit={this.handleFormSubmit.bind(this)}>
            <div className="col-md-5 col-sm-4 col-xs-12">
              <h4 className="form-text text-center">Your Website Url</h4>
              <input
                id="url"
                type="text"
                className="form-control"
                onChange={this.handleInputChange.bind(this)}
                type="text"
                defaultValue="www.infotrack.com.au"
                required
              />
            </div>
            <div className="col-md-5 col-sm-4 col-xs-12">
              <h4 className="form-text text-center">Your keywords</h4>
              <input
                id="keywords"
                type="text"
                className="form-control"
                onChange={this.handleInputChange.bind(this)}
                type="text"
                defaultValue="online title search"
                required
              />
            </div>
            <div className="col-md-2 col-sm-4 col-xs-12">
              <input
                type="submit"
                value="Show Appeareances"
                className="search-form__button"
                disabled={this.state.isPending}
              />
            </div>
          </form>
        </div>
      </div>
    );
  }

  handleInputChange(e) {
    this.setState({[e.target.id]: e.target.value});
  }

  handleFormSubmit(e) {
    e.preventDefault();
    let url = encodeURI(this.state.url);
    let keywords = encodeURI(this.state.keywords);
    this.setState({isPending: true}, this.props.setSearchPending.bind(null, true));
    axios
      .get(`http://localhost:49489/api/search/?url=${url}&keywords=${keywords}`)
      .then(response => {
        this.props.setSearchResult(response.data);
        this.setState({isPending: false}, this.props.setSearchPending.bind(null, false));
      })
      .catch(() => {
        this.setState({errorInSearch: true, isPending: false});
      });
  }
}

const mapStateToProps = () => ({});

const mapDispatchToProps = {
  setSearchResult: searchActions.setSearchResult,
  setSearchPending: searchActions.setSearchPending
};

SearchForm.proptypes = {
  setSearchResult: PropTypes.func,
  setSearchPending: PropTypes.func
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(SearchForm);
