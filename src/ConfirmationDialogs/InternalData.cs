//using System;
//
//namespace ConfirmationDialogs {
//	internal class InternalData<T> where T : class {
//		internal T value;
//
//		public static implicit operator InternalData<T>(T nl) => new InternalData<T>{value=nl};
//
//		public static implicit operator InternalData<T>(DBNull nl)  => new InternalData<T>{value=null};
//	}
//}