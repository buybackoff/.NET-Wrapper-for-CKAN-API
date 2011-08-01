﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Web;
using CkanDotNet.Api.Model;
using RestSharp;
using log4net;
using System.Reflection;
using System.Runtime.Caching;
using CkanDotNet.Api.Helper;

namespace CkanDotNet.Api
{
    /// <summary>
    /// A client for the CKAN API v2.
    /// </summary>
    public class CkanClient
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The supported CKAN api version
        /// </summary>
        private const string apiVersion = "2";

        /// <summary>
        /// Gets or sets the CKAN repository host name
        /// </summary>
        private string Repository { get; set; }

        /// <summary>
        /// Create an instance of the Ckan client.
        /// </summary>
        /// <param name="repository">The hostname of the CKAN repository.</param>
        public CkanClient(string repository)
        {
            this.Repository = repository;
        }

        #region Public Methods

        #region CKAN Model API

        /// <summary>
        /// Get all CKAN packages ids.
        /// CKAN Model Resource: Package Register
        /// </summary>
        /// <returns>A list of package ids.</returns>
        public List<string> GetPackageIds()
        {
            return GetPackageIds(null);
        }

        /// <summary>
        /// Get all CKAN packages ids with caching.
        /// CKAN Model Resource: Package Register
        /// </summary>
        /// <param name="settings">The cache settings.</param>
        /// <returns>A list of package ids.</returns>
        public List<string> GetPackageIds(CacheSettings settings)
        {
            var request = new RestRequest();
            request.Resource = "rest/package";
            List<string> packageIds = Execute<List<string>>(request, settings);
            return packageIds;
        }

        /// <summary>
        /// Get a CKAN package by id or name.
        /// CKAN Model Resource: Package Entity
        /// </summary>
        /// <param name="name">The package name or id.</param>
        /// <returns>The package</returns>
        public Package GetPackage(string id)
        {
            return GetPackage(id, null);
        }

        /// <summary>
        /// Get a CKAN package by id or name with caching.
        /// CKAN Model Resource: Package Entity
        /// </summary>
        /// <param name="name">The package name or id.</param>
        /// <param name="settings">The cache settings.</param>
        /// <returns>The package</returns>
        public Package GetPackage(string id, CacheSettings settings)
        {
            var request = new RestRequest();
            request.Resource = String.Format("rest/package/{0}", id);
            Package package = Execute<Package>(request, settings);
            return package;
        }

        /// <summary>
        /// Get all CKAN group ids.
        /// CKAN Model Resource: Group Register
        /// </summary>
        /// <returns>A list of group ids.</returns>
        public List<string> GetGroupIds()
        {
            return GetGroupIds(null);
        }

        /// <summary>
        /// Get all CKAN group ids with caching.
        /// CKAN Model Resource: Group Register
        /// </summary>
        /// <param name="settings">The cache settings.</param>
        /// <returns>A list of group ids.</returns>
        public List<string> GetGroupIds(CacheSettings settings)
        {
            var request = new RestRequest();
            request.Resource = "rest/group";
            List<string> groupIds = Execute<List<string>>(request, settings);
            return groupIds;
        }

        /// <summary>
        /// Get a CKAN group by id or name.
        /// CKAN Model Resource: Group Entity
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Group GetGroup(string id)
        {
            return GetGroup(id, null);
        }

        /// <summary>
        /// Get a CKAN group by id or name with caching.
        /// CKAN Model Resource: Group Entity
        /// </summary>
        /// <param name="id">The pacakge id or name.</param>
        /// <param name="settings">The cache settings.</param>
        /// <returns></returns>
        public Group GetGroup(string id, CacheSettings settings)
        {
            var request = new RestRequest();
            request.Resource = String.Format("rest/group/{0}", id);
            Group group = Execute<Group>(request, settings);
            return group;
        }

        /// <summary>
        /// Get all CKAN tags
        /// CKAN Model Resource: Tag Register
        /// </summary>
        /// <returns>A list of tags</returns>
        public List<string> GetTags()
        {
            return GetTags(null);
        }

        /// <summary>
        /// Get all CKAN tags with caching.
        /// CKAN Model Resource: Tag Register
        /// </summary>
        /// <param name="settings">The cache settings.</param>
        /// <returns>A list of tags</returns>
        public List<string> GetTags(CacheSettings settings)
        {
            var request = new RestRequest();
            request.Resource = "rest/tag";
            List<string> tags = Execute<List<string>>(request, settings);
            return tags;
        }

        /// <summary>
        /// Get a list of package ids by tag.
        /// CKAN Model Resource: Tag Entity
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public List<string> GetPackageIdsByTag(string tag)
        {
            return GetPackageIdsByTag(tag, null);
        }

        /// <summary>
        /// Get a list of package ids by tag with caching.
        /// CKAN Model Resource: Tag Entity
        /// </summary>
        /// <param name="settings">The cache settings.</param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public List<string> GetPackageIdsByTag(string tag, CacheSettings settings)
        {
            var request = new RestRequest();
            request.Resource = String.Format("rest/tag/{0}", tag);
            List<string> packageIds = Execute<List<string>>(request, settings);
            return packageIds;
        }

        /// <summary>
        /// Get a list of package revision by package id or name.
        /// CKAN Model Resource: Package’s Revisions Entity
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public List<Revision> GetPackageRevisions(string id)
        {
            return GetPackageRevisions(id, null);
        }

        /// <summary>
        /// Get a list of package revision by package id or name with caching.
        /// CKAN Model Resource: Package’s Revisions Entity
        /// </summary>
        /// <param name="id">The package id or name.</param>
        /// <param name="settings">The cache settings.</param>
        /// <returns></returns>
        public List<Revision> GetPackageRevisions(string id, CacheSettings settings)
        {
            var request = new RestRequest();
            request.Resource = String.Format("rest/package/{0}/revisions", id);
            List<Revision> revisions = Execute<List<Revision>>(request, settings);
            return revisions;
        }

        /// <summary>
        /// Get all CKAN revision ids.
        /// CKAN Model Resource: Revision Register
        /// </summary>
        /// <returns>A list of revision ids.</returns>
        public List<string> GetRevisionIds()
        {
            return GetRevisionIds(null);
        }

        /// <summary>
        /// Get all CKAN revision ids with caching.
        /// CKAN Model Resource: Revision Register
        /// </summary>
        /// <param name="settings">The cache settings.</param>
        /// <returns>A list of revision ids.</returns>
        public List<string> GetRevisionIds(CacheSettings settings)
        {
            var request = new RestRequest();
            request.Resource = "rest/revision";
            List<string> revisionIds = Execute<List<string>>(request, settings);
            return revisionIds;
        }

        /// <summary>
        /// Get all CKAN revision ids.
        /// CKAN Model Resource: Revision Register (with since_time)
        /// </summary>
        /// <returns>A list of revision ids.</returns>
        public List<string> GetRevisionIds(DateTime since)
        {
            return GetRevisionIds(since, null);
        }

        /// <summary>
        /// Get all CKAN revision ids with caching.
        /// CKAN Model Resource: Revision Register (with since_time)
        /// </summary>
        /// <param name="settings">The cache settings.</param>
        /// <returns>A list of revision ids.</returns>
        public List<string> GetRevisionIds(DateTime since, CacheSettings settings)
        {
            var request = new RestRequest();
            request.Resource = "rest/revision";
            request.AddParameter("since_time", since);

            List<string> revisionIds = Execute<List<string>>(request, settings);
            return revisionIds;
        }

        /// <summary>
        /// Get a revision by id.
        /// CKAN Model Resource: Revision Entity
        /// </summary>
        /// <param name="id">The revision id</param>
        /// <returns></returns>
        public Revision GetRevision(string id)
        {
            return GetRevision(id, null);
        }

        /// <summary>
        /// Get a revision by id with caching.
        /// CKAN Model Resource: Revision Entity
        /// </summary>
        /// <param name="id">The revision id</param>
        /// <param name="settings">The cache settings.</param>
        /// <returns></returns>
        public Revision GetRevision(string id, CacheSettings settings)
        {
            var request = new RestRequest();
            request.Resource = String.Format("rest/revision/{0}", id);
            Revision revision = Execute<Revision>(request, settings);
            return revision;
        }

        /// <summary>
        /// Get all CKAN licenses.
        /// CKAN Model Resource: License List
        /// </summary>
        /// <returns>A list of licenses.</returns>
        public List<License> GetLicenses()
        {
            return GetLicenses(null);
        }

        /// <summary>
        /// Get all CKAN licenses with caching.
        /// CKAN Model Resource: License List
        /// </summary>
        /// <param name="settings">The cache settings.</param>
        /// <returns>A list of licenses.</returns>
        public List<License> GetLicenses(CacheSettings settings)
        {
            var request = new RestRequest();
            request.Resource = "rest/licenses";
            List<License> licenses = Execute<List<License>>(request, settings);
            return licenses;
        }

        #endregion

        #region CKAN Search API

        /// <summary>
        /// Search for packages in the CKAN repository.
        /// </summary>
        /// <param name="parameters">Provides that parameters to use in the search.</param>
        /// <returns>Search results</returns>
        public PackageSearchResponse<T> SearchPackages<T>(PackageSearchParameters parameters)
        {
            return SearchPackages<T>(parameters, null);

        }

        /// <summary>
        /// Search for packages in the CKAN repository with caching.
        /// </summary>
        /// <param name="parameters">Provides that parameters to use in the search.</param>
        /// <param name="settings">The cache settings.</param>
        /// <returns>Search results</returns>
        public PackageSearchResponse<T> SearchPackages<T>(PackageSearchParameters parameters, CacheSettings settings)
        {
            var request = new RestRequest();
            request.Resource = "search/package";

            // Apply query parameter
            if (!String.IsNullOrEmpty(parameters.Query))
            {
                request.AddParameter("q", parameters.Query);
            }

            // Apply title parameter
            if (!String.IsNullOrEmpty(parameters.Title))
            {
                request.AddParameter("title", parameters.Title);
            }

            // Apply tag parameters
            foreach (var tag in parameters.Tags)
            {
                request.AddParameter("tags", tag);
            }

            // Apply notes parameter
            if (!String.IsNullOrEmpty(parameters.Notes))
            {
                request.AddParameter("notes", parameters.Notes);
            }

            // Apply group parameters
            foreach (var group in parameters.Groups)
            {
                request.AddParameter("groups", group);
            }

            // Apply author parameter
            if (!String.IsNullOrEmpty(parameters.Author))
            {
                request.AddParameter("author", parameters.Author);
            }

            // Apply update_frequency parameter
            if (!String.IsNullOrEmpty(parameters.UpdateFrequency))
            {
                request.AddParameter("update_frequency", parameters.UpdateFrequency);
            }

            // Apply maintainer parameter
            if (!String.IsNullOrEmpty(parameters.Maintainer))
            {
                request.AddParameter("maintainer", parameters.Maintainer);
            }

            // Apply order_by parameter
            if (!String.IsNullOrEmpty(parameters.OrderBy))
            {
                request.AddParameter("order_by", parameters.OrderBy);
            }

            // Set the offset and limit parameters
            request.AddParameter("offset", parameters.Offset);
            request.AddParameter("limit", parameters.Limit);

            // Apply all_fields parameter
            if (typeof(T) == typeof(Package))
            {
                request.AddParameter("all_fields", 1);
            }

            // Apply filter_by_openness parameter
            if (parameters.FilterByOpenness)
            {
                request.AddParameter("filter_by_openness", "1");
            }

            // Apply filter_by_downloadable parameter
            if (parameters.FilterByDownloadable)
            {
                request.AddParameter("filter_by_downloadable", "1");
            }

            // Execute the request
            PackageSearchResponse<T> response = Execute<PackageSearchResponse<T>>(request, settings);

            // If no results, return an empty results object
            if (response == null)
            {
                response = new PackageSearchResponse<T>();
            }

            return response;
        }

        /// <summary>
        /// Search for revisions in the CKAN repository.
        /// </summary>
        /// <param name="parameters">Provides that parameters to use in the search.</param>
        /// <returns>Search results</returns>
        public List<string> SearchRevisions(RevisionSearchParameters parameters)
        {
            return SearchRevisions(parameters, null);
        }

        /// <summary>
        /// Search for revisions in the CKAN repository with caching.
        /// </summary>
        /// <param name="parameters">Provides that parameters to use in the search.</param>
        /// <param name="settings">The cache settings.</param>
        /// <returns>Search results</returns>
        public List<string> SearchRevisions(RevisionSearchParameters parameters, CacheSettings settings)
        {
            var request = new RestRequest();
            request.Resource = "search/revision";

            // Apply since_id parameter
            if (!String.IsNullOrEmpty(parameters.SinceId))
            {
                request.AddParameter("since_id", parameters.SinceId);
            }

            // Apply since_time parameter
            if (parameters.SinceTime != DateTime.MinValue)
            {
                request.AddParameter("since_time", parameters.SinceTime);
            }

            // Execute the request
            List<string> revisionIds = Execute<List<string>>(request, settings);

            // If no results, return an empty results object
            if (revisionIds == null)
            {
                revisionIds = new List<string>();
            }

            return revisionIds;
        }

        /// <summary>
        /// Search for resources in the CKAN repository.
        /// </summary>
        /// <param name="parameters">Provides that parameters to use in the search.</param>
        /// <returns>Search results</returns>
        public ResourceSearchResponse<T> SearchResources<T>(ResourceSearchParameters parameters)
        {
            return SearchResources<T>(parameters, null);
        }

        /// <summary>
        /// Search for resources in the CKAN repository with caching.
        /// </summary>
        /// <param name="parameters">Provides that parameters to use in the search.</param>
        /// <param name="settings">The cache settings.</param>
        /// <returns>Search results</returns>
        public ResourceSearchResponse<T> SearchResources<T>(ResourceSearchParameters parameters, CacheSettings settings)
        {
            var request = new RestRequest();
            request.Resource = "search/resource";

            // Apply url parameter
            if (!String.IsNullOrEmpty(parameters.Url))
            {
                request.AddParameter("url", parameters.Url);
            }

            // Apply format parameter
            if (!String.IsNullOrEmpty(parameters.Format))
            {
                request.AddParameter("format", parameters.Format);
            }

            // Apply description parameter
            if (!String.IsNullOrEmpty(parameters.Description))
            {
                request.AddParameter("description", parameters.Description);
            }

            // Apply hash parameter
            if (!String.IsNullOrEmpty(parameters.Hash))
            {
                request.AddParameter("hash", parameters.Hash);
            }

            // Set the offset and limit parameters
            request.AddParameter("offset", parameters.Offset);
            request.AddParameter("limit", parameters.Limit);

            // Apply all_fields parameter
            if (typeof(T) == typeof(Resource))
            {
                request.AddParameter("all_fields", 1);
            }

            // Execute the request
            ResourceSearchResponse<T> response = Execute<ResourceSearchResponse<T>>(request, settings);

            // If no results, return an empty results object
            if (response == null)
            {
                response = new ResourceSearchResponse<T>();
            }

            return response;
        }
        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Execute a request for the CKAN REST API with support for individual request caching.
        /// </summary>
        /// <typeparam name="T">The type that will be used for the JSON returned.</typeparam>
        /// <param name="request">The RestRequest</param>
        /// <param name="settings">The cache settings.</param>
        /// <returns></returns>
        private T Execute<T>(RestRequest request, CacheSettings settings) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = String.Format("http://{0}/api/{1}/", this.Repository, apiVersion);

            var url = GetRequestUrl(client, request);

            // Log the request that is being sent to CKAN
            log.InfoFormat("Prepared request for CKAN repository: {0}", url);

            // Get the response
            RestResponse<T> response = null;

            if (settings == null)
            {
                // If no caching call directly
                response = client.Execute<T>(request);
                log.DebugFormat("Response recieved: {0}", response.Content);
            }
            else
            {
                // Otherwise get from the cache or update if not cached
                response = CacheHelper.Get<T>(url);
                if (response != null)
                {
                    log.DebugFormat("Response retrieved from cache: {0}", response.Content);
                }
                else
                {
                    response = CacheHelper.Insert<T>(url, client.Execute<T>(request), settings);
                    log.DebugFormat("Response cached: {0}", response.Content);
                }
            }

            return response.Data;
        }

        /// <summary>
        /// Gets the URL represtation of the request that will be submitted to CKAN
        /// for diagnostic purposes.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        private string GetRequestUrl(RestClient client, RestRequest request)
        {
            StringBuilder sb = new StringBuilder();

            // Append the base url
            sb.Append(client.BaseUrl);
            sb.Append("/");
            sb.Append(request.Resource);

            // Append the querystring parameters
            if (request.Parameters.Count > 0)
            {
                sb.Append("?");
                bool first = true;
                foreach (var parameter in request.Parameters)
                {
                    if (!first)
                    {
                        sb.Append("&");
                    }
                    else
                    {
                        first = false;
                    }

                    sb.AppendFormat("{0}={1}", parameter.Name, parameter.Value);
                }
            }

            return sb.ToString();
        }

        #endregion
    }
}
