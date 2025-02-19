﻿using Common.Core.CQRS;

namespace Basket.Application.Commands.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;
    public record DeleteBasketResult(bool IsSuccess);
}
