using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;
using Ekip.Framework.Core.Resources;

namespace Ekip.Framework.Core.ErrorHandling
{
    [Serializable()]
    public class ValidateException : Exception, ISerializable
    {
        #region Fields

        private string caption = null;
        private List<ValidationError> validationErrors = null;

        #endregion

        #region Properties

        public string Caption
        {
            get { return SystemMessages.Validate_Error_Caption; }
            set { caption = value; }
        }

        public List<ValidationError> ValidationErrors
        {
            get
            {
                if (validationErrors == null)
                    validationErrors = new List<ValidationError>();
                return validationErrors;
            }
            set
            {
                validationErrors = value;
            }
        }

        #endregion

        public ValidateException(string message = null)
            : base(SystemMessages.Validate_Error_Content)
        {
        }

        public ValidateException(string message, Exception innerException)
            : base(SystemMessages.Validate_Error_Content, innerException)
        {
        }

        public ValidateException(string message, string caption, List<ValidationError> validationErrors)
            : base(SystemMessages.Validate_Error_Content)
        {
            this.Caption = caption;
            this.ValidationErrors = validationErrors;
        }

        public ValidateException(string message, string caption, List<ValidationError> validationErrors, Exception innerException)
            : base(SystemMessages.Validate_Error_Content, innerException)
        {
            this.Caption = caption;
            this.ValidationErrors = validationErrors;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected ValidateException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Caption = info.GetString("Caption");
            this.ValidationErrors = (List<ValidationError>)info.GetValue("ValidationErrors", typeof(List<ValidationError>));
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("Caption", this.Caption);
            info.AddValue("ValidationErrors", this.ValidationErrors, typeof(List<ValidationError>));
            base.GetObjectData(info, context);
        }
    }

    [Serializable()]
    public class ValidationError
    {
        public string PropertyName { get; set; }

        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", PropertyName, ErrorMessage);
        }
    }
}
