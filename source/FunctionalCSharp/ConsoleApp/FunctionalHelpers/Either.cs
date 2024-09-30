using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.FunctionalHelpers {
	public class Either<L, R> {
		private readonly L _left;
		private readonly R _right;
		public bool IsLeft { get; private set; }
		public bool IsRight => !IsLeft;

		private Either(L left, R right, bool isLeft) {
			_left = left;
			_right = right;
			IsLeft = isLeft;
		}

		public static Either<L, R> Left(L left) => new Either<L, R>(left, default(R), true);

		public static Either<L, R> Right(R right) => new Either<L, R>(default(L), right, false);
		public TResult Match<TResult>(Func<L, TResult> onLeft, Func<R, TResult> onRight) =>
			 IsLeft ? onLeft(_left) : onRight(_right);

	}
}
