import React, {Component} from 'react';
import PropTypes from 'prop-types';
import * as searchActions from '../../../actions/searchResultActionCreator';
import {connect} from 'react-redux';
import config from '../../../config/config';
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
                defaultValue={this.props.defaultUrl}
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
                defaultValue={this.props.defaultKeyWords}
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
      .get(`${config.serverUrl}/api/search/?url=${url}&keywords=${keywords}`)
      .then(response => {        
        this.setState({isPending: false}, this.props.setSearchResult.bind(null,response.data));
      })
      .catch(() => {
        this.setState({errorInSearch: true, isPending: false}, this.props.setSearchError.bind(null, true));
      });
  }
}

const mapStateToProps = () => ({});

const mapDispatchToProps = {
  setSearchResult: searchActions.setSearchResult,
  setSearchPending: searchActions.setSearchPending,
  setSearchError: searchActions.setSearchError
};

SearchForm.proptypes = {
  setSearchResult: PropTypes.func,
  setSearchPending: PropTypes.func,
  setSearchError: PropTypes.func,
  defaultKeyWords: PropTypes.string,
  defaultUrl: PropTypes.string
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(SearchForm);
