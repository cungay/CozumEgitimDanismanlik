﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ekip.Framework.Entities.Validation
{
   /// <summary>
   /// Object representing a validation rule for an object
   /// </summary>
   internal class ValidationRuleInfo
   {
      private object _target;
      private ValidationRuleHandler _handler;
      private string _ruleName = String.Empty;
      private ValidationRuleArgs _args;

      /// <summary>
      /// Returns a text representation of the rule which is the <see cref="RuleName"/>.
      /// </summary>
      public override string ToString()
      {
         return _ruleName;
      }

      /// <summary>
      /// Gets the name of the rule.
      /// </summary>
      /// <remarks>
      /// The rule's name must be unique and is used
      /// to identify a broken rule in the <see cref="BrokenRulesList"/>.
      /// </remarks>
      public string RuleName
      {
         get { return _ruleName; }
      }

      /// <summary>
      /// Returns information about the property that is associated with the rule.
      /// </summary>
      public ValidationRuleArgs ValidationRuleArgs
      {
         get { return _args; }
      }

      /// <summary>
      /// Creates and initializes the rule.
      /// </summary>
      /// <param name="target">Object reference containing the data to validate.</param>
      /// <param name="handler">The address of the method implementing <see cref="ValidationRuleHandler"/>.</param>
      /// <param name="propertyName">The name of the property to which the rule applies.</param>
      public ValidationRuleInfo(object target, ValidationRuleHandler handler, string propertyName)
            :this(target, handler, new ValidationRuleArgs(propertyName))
      {
      }

      /// <summary>
      /// Creates and initializes the rule.
      /// </summary>
      /// <param name="target">Object reference containing the data to validate.</param>
      /// <param name="handler">The address of the method implementing <see cref="ValidationRuleHandler"/>.</param>
      /// <param name="args">A <see cref="ValidationRuleArgs"/> object.</param>
      public ValidationRuleInfo(object target, ValidationRuleHandler handler, ValidationRuleArgs args)
      {
         _target = target;
         _handler = handler;
         _args = args;
         _ruleName = _handler.Method.Name + "!" + _args.ToString();
      }

      /// <summary>
      /// Invokes the rule to validate the data.
      /// </summary>
      /// <returns>True if the data is valid, False if the data is invalid.</returns>
      public bool Invoke()
      {
         return _handler.Invoke(_target, _args);
      }
   }
}
