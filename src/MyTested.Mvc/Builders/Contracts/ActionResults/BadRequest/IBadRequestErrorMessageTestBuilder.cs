﻿namespace MyTested.Mvc.Builders.Contracts.ActionResults.BadRequest
{
    using Base;

    /// <summary>
    /// Used for testing specific bad request text error messages.
    /// </summary>
    public interface IBadRequestErrorMessageTestBuilder : IBaseTestBuilderWithInvokedAction
    {
        /// <summary>
        /// Tests whether particular error message is equal to given message.
        /// </summary>
        /// <param name="errorMessage">Expected error message for particular key.</param>
        /// <returns>HTTP bad request test builder.</returns>
        IAndBadRequestTestBuilder ThatEquals(string errorMessage);

        /// <summary>
        /// Tests whether particular error message begins with given message.
        /// </summary>
        /// <param name="beginMessage">Expected beginning for particular error message.</param>
        /// <returns>HTTP bad request test builder.</returns>
        IAndBadRequestTestBuilder BeginningWith(string beginMessage);

        /// <summary>
        /// Tests whether particular error message ends with given message.
        /// </summary>
        /// <param name="endMessage">Expected ending for particular error message.</param>
        /// <returns>HTTP bad request test builder.</returns>
        IAndBadRequestTestBuilder EndingWith(string endMessage);

        /// <summary>
        /// Tests whether particular error message contains given message.
        /// </summary>
        /// <param name="containsMessage">Expected containing string for particular error message.</param>
        /// <returns>HTTP bad request test builder.</returns>
        IAndBadRequestTestBuilder Containing(string containsMessage);
    }
}