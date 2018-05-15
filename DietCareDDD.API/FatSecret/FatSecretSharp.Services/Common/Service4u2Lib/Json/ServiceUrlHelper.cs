
namespace Service4u2.Json
{
    /// <summary>
    /// A static helper class for constructing Json urls.
    /// </summary>
    public class ServiceUrlHelper
    {
        /// <summary>
        /// The service base URL.
        /// </summary>
        protected string serviceBaseUrl = string.Empty;

        /// <summary>
        /// The service url format.
        /// </summary>
        protected string serviceFormat = "{0}/{1}/{2}?{3}";

        public ServiceUrlHelper(string baseUrl)
        {
            this.serviceBaseUrl = baseUrl;
        }

        /// <summary>
        /// Builds the parm string.
        /// </summary>
        /// <param name="parmKeyValue">The parm key value.</param>
        /// <returns>A url encoded string representing the passed in parameters.</returns>
        public string BuildParmString(params string[] parmKeyValue)
        {
            string result = string.Empty;

            if (parmKeyValue.Length > 0)
            {
                result = string.Join("&", parmKeyValue);
            }

            return result;
        }

        /// <summary>
        /// Gets the controller action parameter URL.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="parmString">The parm string.</param>
        /// <returns>A url representing the passed in parameters.</returns>
        public string GetControllerActionParameterUrl(string controller, string action, params string[] parmString)
        {
            return GetControllerActionParameterUrl(controller, action, BuildParmString(parmString));
        }

        /// <summary>
        /// Gets the controller action parameter URL.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="parmString">The parm string.</param>
        /// <returns>A url representing the passed in parameters.</returns>
        public string GetControllerActionParameterUrl(string controller, string action, string parmString)
        {
            var result = string.Format(serviceFormat, serviceBaseUrl, controller, action, parmString);
            if (parmString == string.Empty)
                result = result.TrimEnd('?');

            return result;
        }

        /// <summary>
        /// Gets the controller action id URL.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="id">The id.</param>
        /// <returns>a url representing the passed in parameters</returns>
        public string GetControllerActionIdUrl(string controller, string action, int id)
        {
            return GetControllerActionIdUrl(controller, action, id.ToString());
        }

        /// <summary>
        /// Gets the controller action id URL.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="id">The id.</param>
        /// <returns>a url representing the passed in parameters</returns>
        public string GetControllerActionIdUrl(string controller, string action, string id)
        {
            return string.Format(serviceFormat, serviceBaseUrl, controller, action, id).Replace('?', '/');
        }
    }
}
