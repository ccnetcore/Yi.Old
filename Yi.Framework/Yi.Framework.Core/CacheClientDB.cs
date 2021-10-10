using Microsoft.Extensions.Options;
using ServiceStack;
using ServiceStack.Redis;
using ServiceStack.Redis.Pipeline;
using ServiceStack.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CC.ElectronicCommerce.Common.IOCOptions;

namespace CC.ElectronicCommerce.Core
{
	public class CacheClientDB : IDisposable
	{
		private readonly RedisConnOptions _RedisOptions;

		#region TestRedisCrack
		//static CacheClientDB()
		//{
		//	try
		//	{
		//		Parallel.For(0, 10000, (i) =>
		//		{
		//			using (RedisClient client = new RedisClient("192.168.3.254"))
		//			{
		//				client.Set("name" + i, i);
		//				client.Incr("name" + i);
		//				Console.WriteLine(i);
		//			}

		//		});
		//		Console.WriteLine("ok");

		//		Console.WriteLine("Hello World!");
		//	}
		//	catch (Exception ex)
		//	{
		//		Console.WriteLine(ex.Message);
		//	}
		//}
		#endregion
		public CacheClientDB(IOptionsMonitor<RedisConnOptions> jwtTokenOptions)
		{
			this._RedisOptions = jwtTokenOptions.CurrentValue;
			client = new RedisClient(_RedisOptions.Host, _RedisOptions.Prot, _RedisOptions.Password, _RedisOptions.DB);
		}
		// 管道模式 三种模式
		public IRedisClient GetClient()
		{
			return client;
		}
		private IRedisClient client;

		public void Dispose()
		{

			this.TryCatchException(delegate
			{
				this.client.Dispose();
			}, string.Empty);
		}
		// 为了以后全链路做准备
		private void TryCatchException(Action action, string key)
		{
			try
			{
				action();
			}
			catch (Exception e)
			{

				Console.WriteLine(e.Message);
			}
		}

		private T TryCatch<T>(Func<T> action, string key)
		{
			Stopwatch sw = Stopwatch.StartNew();
			//Exception ex = null;
			//bool isError = false;
			T result;
			try
			{
				result = action();
			}
			catch (Exception exinfo)
			{
				object p=null;
				result =(T)p;
				//isError = true;
				Console.WriteLine(exinfo);

			}
			finally
			{

				sw.Stop();

			}
			
			return result;
		}

		private void TryCatch(Action action, string key)
		{

			Stopwatch sw = Stopwatch.StartNew();
			//bool isError = false;
			//Exception ex = null;
			try
			{
				action();
			}
			catch (Exception exinfo)
			{

				//isError = true;
				Console.WriteLine(exinfo);
			}
			finally
			{
				sw.Stop();

			}
		}
		public bool Add<T>(string key, T value)
		{

			return this.TryCatch<bool>(() => this.client.Add<T>(key, value), key);
		}
		/// <summary>
		///  简单模式  事务模式
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <param name="expiresAt"></param>
		/// <returns></returns>
		public bool Add<T>(string key, T value, DateTime expiresAt)
		{

			return this.TryCatch<bool>(() => this.client.Add<T>(key, value, expiresAt), key);
		}

		public bool Add<T>(string key, T value, TimeSpan expiresIn)
		{
			return this.TryCatch<bool>(() => this.client.Add<T>(key, value, expiresIn), key);
		}

		public long Decrement(string key, uint amount)
		{
			return this.TryCatch<long>(() => this.client.Decrement(key, amount), key);
		}

		public void FlushAll()
		{
			this.TryCatch(delegate
			{
				this.client.FlushAll();
			}, string.Empty);
		}

		public T Get<T>(string key)
		{
			return this.TryCatch<T>(() => this.client.Get<T>(key), key);
		}

		public IDictionary<string, T> GetAll<T>(IEnumerable<string> keys)
		{
			return this.TryCatch<IDictionary<string, T>>(() => this.client.GetAll<T>(keys), keys.FirstOrDefault<string>());
		}

		public long Increment(string key, uint amount)
		{
			return this.TryCatch<long>(() => this.client.Increment(key, amount), key);
		}

		public bool Remove(string key)
		{
			return this.TryCatch<bool>(() => this.client.Remove(key), key);
		}

		public void RemoveAll(IEnumerable<string> keys)
		{
			this.TryCatch(delegate
			{
				this.client.RemoveAll(keys);
			}, keys.FirstOrDefault<string>());
		}

		public bool Replace<T>(string key, T value)
		{
			return this.TryCatch<bool>(() => this.client.Replace<T>(key, value), key);
		}

		public bool Replace<T>(string key, T value, DateTime expiresAt)
		{
			return this.TryCatch<bool>(() => this.client.Replace<T>(key, value, expiresAt), key);
		}

		public bool Replace<T>(string key, T value, TimeSpan expiresIn)
		{
			return this.TryCatch<bool>(() => this.client.Replace<T>(key, value, expiresIn), key);
		}

		public bool Set<T>(string key, T value)
		{
			return this.TryCatch<bool>(() => this.client.Set<T>(key, value), key);
		}

		public bool Set<T>(string key, T value, DateTime expiresAt)
		{
			return this.TryCatch<bool>(() => this.client.Set<T>(key, value, expiresAt), key);
		}

		public bool Set<T>(string key, T value, TimeSpan expiresIn)
		{
			return this.TryCatch<bool>(() => this.client.Set<T>(key, value, expiresIn), key);
		}

		public void SetAll<T>(IDictionary<string, T> values)
		{
			this.TryCatch(delegate
			{
				this.client.SetAll<T>(values);
			}, values.Keys.FirstOrDefault<string>());
		}


		public void Delete<T>(T entity) where T : class, new()
		{
			this.TryCatch(delegate
			{
				this.client.Delete<T>(entity);
			}, string.Empty);
		}

		public void DeleteAll<TEntity>() where TEntity : class, new()
		{
			this.TryCatch(delegate
			{
				this.client.DeleteAll<TEntity>();
			}, string.Empty);
		}

		public void DeleteById<T>(object id) where T : class, new()
		{
			this.TryCatch(delegate
			{
				this.client.DeleteById<T>(id);
			}, string.Empty);
		}

		public void DeleteByIds<T>(ICollection ids) where T : class, new()
		{
			this.TryCatch(delegate
			{
				this.client.DeleteById<T>(ids);
			}, string.Empty);
		}

		public T GetById<T>(object id) where T : class, new()
		{
			return this.TryCatch<T>(() => this.client.GetById<T>(id), string.Empty);
		}

		public IList<T> GetByIds<T>(ICollection ids) where T : class, new()
		{
			return this.TryCatch<IList<T>>(() => this.client.GetByIds<T>(ids), string.Empty);
		}

		public T Store<T>(T entity) where T : class, new()
		{
			return this.TryCatch<T>(() => this.client.Store<T>(entity), string.Empty);
		}

		public void StoreAll<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, new()
		{
			this.TryCatch(delegate
			{
				this.client.StoreAll<TEntity>(entities);
			}, string.Empty);
		}

		public void AddItemToList(string listId, string value)
		{
			this.TryCatch(delegate
			{
				this.client.AddItemToList(listId, value);
			}, listId);
		}

		public void AddItemToSet(string setId, string item)
		{
			this.TryCatch(delegate
			{
				this.client.AddItemToSet(setId, item);
			}, setId);
		}

		public bool AddItemToSortedSet(string setId, string value)
		{
			return this.TryCatch<bool>(() => this.client.AddItemToSortedSet(setId, value), setId);
		}

		public bool AddItemToSortedSet(string setId, string value, double score)
		{
			return this.TryCatch<bool>(() => this.client.AddItemToSortedSet(setId, value, score), setId);
		}

		public void AddRangeToList(string listId, List<string> values)
		{
			this.TryCatch(delegate
			{
				this.client.AddRangeToList(listId, values);
			}, listId);
		}

		public void AddRangeToSet(string setId, List<string> items)
		{
			this.TryCatch(delegate
			{
				this.client.AddRangeToSet(setId, items);
			}, setId);
		}

		public bool AddRangeToSortedSet(string setId, List<string> values, double score)
		{
			return this.TryCatch<bool>(() => this.client.AddRangeToSortedSet(setId, values, score), setId);
		}

		public bool AddRangeToSortedSet(string setId, List<string> values, long score)
		{
			return this.TryCatch<bool>(() => this.client.AddRangeToSortedSet(setId, values, score), setId);
		}

		public long AppendToValue(string key, string value)
		{
			return this.TryCatch<long>(() => this.client.AppendToValue(key, value), key);
		}

		public string BlockingDequeueItemFromList(string listId, TimeSpan? timeOut)
		{
			return this.TryCatch<string>(() => this.client.BlockingDequeueItemFromList(listId, timeOut), listId);
		}

		public KeyValuePair<string, string> BlockingDequeueItemFromLists(string[] listIds, TimeSpan? timeOut)
		{
			return this.TryCatch<KeyValuePair<string, string>>(delegate
			{
				ItemRef item = this.client.BlockingDequeueItemFromLists(listIds, timeOut);
				return new KeyValuePair<string, string>(item.Id, item.Item);
			}, listIds[0]);
		}

		public string BlockingPopAndPushItemBetweenLists(string fromListId, string toListId, TimeSpan? timeOut)
		{
			return this.TryCatch<string>(() => this.client.BlockingPopAndPushItemBetweenLists(fromListId, toListId, timeOut), fromListId);
		}

		public string BlockingPopItemFromList(string listId, TimeSpan? timeOut)
		{
			return this.TryCatch<string>(() => this.client.BlockingPopItemFromList(listId, timeOut), listId);
		}

		public KeyValuePair<string, string> BlockingPopItemFromLists(string[] listIds, TimeSpan? timeOut)
		{
			return this.TryCatch<KeyValuePair<string, string>>(delegate
			{
				ItemRef item = this.client.BlockingPopItemFromLists(listIds, timeOut);
				return new KeyValuePair<string, string>(item.Id, item.Item);
			}, listIds[0]);
		}

		public string BlockingRemoveStartFromList(string listId, TimeSpan? timeOut)
		{
			return this.TryCatch<string>(() => this.client.BlockingRemoveStartFromList(listId, timeOut), listId);
		}

		public KeyValuePair<string, string> BlockingRemoveStartFromLists(string[] listIds, TimeSpan? timeOut)
		{
			return this.TryCatch<KeyValuePair<string, string>>(delegate
			{
				ItemRef item = this.client.BlockingRemoveStartFromLists(listIds, timeOut);
				return new KeyValuePair<string, string>(item.Id, item.Item);
			}, listIds[0]);
		}

		public bool ContainsKey(string key)
		{
			return this.TryCatch<bool>(() => this.client.ContainsKey(key), key);
		}

		public long DecrementValue(string key)
		{
			return this.TryCatch<long>(() => this.client.DecrementValue(key), key);
		}

		public long DecrementValueBy(string key, int count)
		{
			return this.TryCatch<long>(() => this.client.DecrementValueBy(key, count), key);
		}

		public string DequeueItemFromList(string listId)
		{
			return this.TryCatch<string>(() => this.client.DequeueItemFromList(listId), listId);
		}

		public void EnqueueItemOnList(string listId, string value)
		{
			this.TryCatch(delegate
			{
				this.client.EnqueueItemOnList(listId, value);
			}, listId);
		}

		public bool ExpireEntryAt(string key, DateTime expireAt)
		{
			return this.TryCatch<bool>(() => this.client.ExpireEntryAt(key, expireAt), key);
		}

		public bool ExpireEntryIn(string key, TimeSpan expireIn)
		{
			return this.TryCatch<bool>(() => this.client.ExpireEntryIn(key, expireIn), key);
		}

		public Dictionary<string, string> GetAllEntriesFromHash(string hashId)
		{
			return this.TryCatch<Dictionary<string, string>>(() => this.client.GetAllEntriesFromHash(hashId), hashId);
		}

		public List<string> GetAllItemsFromList(string listId)
		{
			return this.TryCatch<List<string>>(() => this.client.GetAllItemsFromList(listId), listId);
		}

		public HashSet<string> GetAllItemsFromSet(string setId)
		{
			return this.TryCatch<HashSet<string>>(() => this.client.GetAllItemsFromSet(setId), setId);
		}

		public List<string> GetAllItemsFromSortedSet(string setId)
		{
			return this.TryCatch<List<string>>(() => this.client.GetAllItemsFromSortedSet(setId), setId);
		}

		public List<string> GetAllItemsFromSortedSetDesc(string setId)
		{
			return this.TryCatch<List<string>>(() => this.client.GetAllItemsFromSortedSetDesc(setId), setId);
		}

		public List<string> GetAllKeys()
		{
			return this.TryCatch<List<string>>(() => this.client.GetAllKeys(), string.Empty);
		}

		public IDictionary<string, double> GetAllWithScoresFromSortedSet(string setId)
		{
			return this.TryCatch<IDictionary<string, double>>(() => this.client.GetAllWithScoresFromSortedSet(setId), setId);
		}

		public string GetAndSetEntry(string key, string value)
		{
			return this.TryCatch<string>(() => this.client.GetAndSetValue(key, value), key);
		}

		public HashSet<string> GetDifferencesFromSet(string fromSetId, params string[] withSetIds)
		{
			return this.TryCatch<HashSet<string>>(() => this.client.GetDifferencesFromSet(fromSetId, withSetIds), fromSetId);
		}

		public T GetFromHash<T>(object id)
		{
			return this.TryCatch<T>(() => this.client.GetFromHash<T>(id), string.Empty);
		}

		public long GetHashCount(string hashId)
		{
			return this.TryCatch<long>(() => this.client.GetHashCount(hashId), hashId);
		}

		public List<string> GetHashKeys(string hashId)
		{
			return this.TryCatch<List<string>>(() => this.client.GetHashKeys(hashId), hashId);
		}

		public List<string> GetHashValues(string hashId)
		{
			return this.TryCatch<List<string>>(() => this.client.GetHashValues(hashId), hashId);
		}

		public HashSet<string> GetIntersectFromSets(params string[] setIds)
		{
			return this.TryCatch<HashSet<string>>(() => this.client.GetIntersectFromSets(setIds), setIds[0]);
		}

		public string GetItemFromList(string listId, int listIndex)
		{
			return this.TryCatch<string>(() => this.client.GetItemFromList(listId, listIndex), listId);
		}

		public long GetItemIndexInSortedSet(string setId, string value)
		{
			return this.TryCatch<long>(() => this.client.GetItemIndexInSortedSet(setId, value), setId);
		}

		public long GetItemIndexInSortedSetDesc(string setId, string value)
		{
			return this.TryCatch<long>(() => this.client.GetItemIndexInSortedSetDesc(setId, value), setId);
		}

		public double GetItemScoreInSortedSet(string setId, string value)
		{
			return this.TryCatch<double>(() => this.client.GetItemScoreInSortedSet(setId, value), setId);
		}

		public long GetListCount(string listId)
		{
			return this.TryCatch<long>(() => this.client.GetListCount(listId), listId);
		}

		public string GetRandomItemFromSet(string setId)
		{
			return this.TryCatch<string>(() => this.client.GetRandomItemFromSet(setId), setId);
		}

		public List<string> GetRangeFromList(string listId, int startingFrom, int endingAt)
		{
			return this.TryCatch<List<string>>(() => this.client.GetRangeFromList(listId, startingFrom, endingAt), listId);
		}

		public List<string> GetRangeFromSortedList(string listId, int startingFrom, int endingAt)
		{
			return this.TryCatch<List<string>>(() => this.client.GetRangeFromSortedList(listId, startingFrom, endingAt), listId);
		}

		public List<string> GetRangeFromSortedSet(string setId, int fromRank, int toRank)
		{
			return this.TryCatch<List<string>>(() => this.client.GetRangeFromSortedSet(setId, fromRank, toRank), setId);
		}

		public List<string> GetRangeFromSortedSetByHighestScore(string setId, double fromScore, double toScore)
		{
			return this.TryCatch<List<string>>(() => this.client.GetRangeFromSortedSetByHighestScore(setId, fromScore, toScore), setId);
		}

		public List<string> GetRangeFromSortedSetByHighestScore(string setId, long fromScore, long toScore)
		{
			return this.TryCatch<List<string>>(() => this.client.GetRangeFromSortedSetByHighestScore(setId, fromScore, toScore), setId);
		}

		public List<string> GetRangeFromSortedSetByHighestScore(string setId, string fromStringScore, string toStringScore)
		{
			return this.TryCatch<List<string>>(() => this.client.GetRangeFromSortedSetByHighestScore(setId, fromStringScore, toStringScore), setId);
		}

		public List<string> GetRangeFromSortedSetByHighestScore(string setId, double fromScore, double toScore, int? skip, int? take)
		{
			return this.TryCatch<List<string>>(() => this.client.GetRangeFromSortedSetByHighestScore(setId, fromScore, toScore, skip, take), setId);
		}

		public List<string> GetRangeFromSortedSetByHighestScore(string setId, long fromScore, long toScore, int? skip, int? take)
		{
			return this.TryCatch<List<string>>(() => this.client.GetRangeFromSortedSetByHighestScore(setId, fromScore, toScore, skip, take), setId);
		}

		public List<string> GetRangeFromSortedSetByHighestScore(string setId, string fromStringScore, string toStringScore, int? skip, int? take)
		{
			return this.TryCatch<List<string>>(() => this.client.GetRangeFromSortedSetByHighestScore(setId, fromStringScore, toStringScore, skip, take), setId);
		}

		public List<string> GetRangeFromSortedSetByLowestScore(string setId, double fromScore, double toScore)
		{
			return this.TryCatch<List<string>>(() => this.client.GetRangeFromSortedSetByLowestScore(setId, fromScore, toScore), setId);
		}

		public List<string> GetRangeFromSortedSetByLowestScore(string setId, long fromScore, long toScore)
		{
			return this.TryCatch<List<string>>(() => this.client.GetRangeFromSortedSetByLowestScore(setId, fromScore, toScore), setId);
		}

		public List<string> GetRangeFromSortedSetByLowestScore(string setId, string fromStringScore, string toStringScore)
		{
			return this.TryCatch<List<string>>(() => this.client.GetRangeFromSortedSetByLowestScore(setId, fromStringScore, toStringScore), setId);
		}

		public List<string> GetRangeFromSortedSetByLowestScore(string setId, double fromScore, double toScore, int? skip, int? take)
		{
			return this.TryCatch<List<string>>(() => this.client.GetRangeFromSortedSetByLowestScore(setId, fromScore, toScore, skip, take), setId);
		}

		public List<string> GetRangeFromSortedSetByLowestScore(string setId, long fromScore, long toScore, int? skip, int? take)
		{
			return this.TryCatch<List<string>>(() => this.client.GetRangeFromSortedSetByLowestScore(setId, fromScore, toScore, skip, take), setId);
		}

		public List<string> GetRangeFromSortedSetByLowestScore(string setId, string fromStringScore, string toStringScore, int? skip, int? take)
		{
			return this.TryCatch<List<string>>(() => this.client.GetRangeFromSortedSetByLowestScore(setId, fromStringScore, toStringScore, skip, take), setId);
		}

		public List<string> GetRangeFromSortedSetDesc(string setId, int fromRank, int toRank)
		{
			return this.TryCatch<List<string>>(() => this.client.GetRangeFromSortedSetDesc(setId, fromRank, toRank), setId);
		}

		public IDictionary<string, double> GetRangeWithScoresFromSortedSet(string setId, int fromRank, int toRank)
		{
			return this.TryCatch<IDictionary<string, double>>(() => this.client.GetRangeWithScoresFromSortedSet(setId, fromRank, toRank), setId);
		}

		public IDictionary<string, double> GetRangeWithScoresFromSortedSetByHighestScore(string setId, double fromScore, double toScore)
		{
			return this.TryCatch<IDictionary<string, double>>(() => this.client.GetRangeWithScoresFromSortedSetByHighestScore(setId, fromScore, toScore), setId);
		}

		public IDictionary<string, double> GetRangeWithScoresFromSortedSetByHighestScore(string setId, long fromScore, long toScore)
		{
			return this.TryCatch<IDictionary<string, double>>(() => this.client.GetRangeWithScoresFromSortedSetByHighestScore(setId, fromScore, toScore), setId);
		}

		public IDictionary<string, double> GetRangeWithScoresFromSortedSetByHighestScore(string setId, string fromStringScore, string toStringScore)
		{
			return this.TryCatch<IDictionary<string, double>>(() => this.client.GetRangeWithScoresFromSortedSetByHighestScore(setId, fromStringScore, toStringScore), setId);
		}

		public IDictionary<string, double> GetRangeWithScoresFromSortedSetByHighestScore(string setId, double fromScore, double toScore, int? skip, int? take)
		{
			return this.TryCatch<IDictionary<string, double>>(() => this.client.GetRangeWithScoresFromSortedSetByHighestScore(setId, fromScore, toScore, skip, take), setId);
		}

		public IDictionary<string, double> GetRangeWithScoresFromSortedSetByHighestScore(string setId, long fromScore, long toScore, int? skip, int? take)
		{
			return this.TryCatch<IDictionary<string, double>>(() => this.client.GetRangeWithScoresFromSortedSetByHighestScore(setId, fromScore, toScore, skip, take), setId);
		}

		public IDictionary<string, double> GetRangeWithScoresFromSortedSetByHighestScore(string setId, string fromStringScore, string toStringScore, int? skip, int? take)
		{
			return this.TryCatch<IDictionary<string, double>>(() => this.client.GetRangeWithScoresFromSortedSetByHighestScore(setId, fromStringScore, toStringScore, skip, take), setId);
		}

		public IDictionary<string, double> GetRangeWithScoresFromSortedSetByLowestScore(string setId, double fromScore, double toScore)
		{
			return this.TryCatch<IDictionary<string, double>>(() => this.client.GetRangeWithScoresFromSortedSetByHighestScore(setId, fromScore, toScore), setId);
		}

		public IDictionary<string, double> GetRangeWithScoresFromSortedSetByLowestScore(string setId, long fromScore, long toScore)
		{
			return this.TryCatch<IDictionary<string, double>>(() => this.client.GetRangeWithScoresFromSortedSetByLowestScore(setId, fromScore, toScore), setId);
		}

		public IDictionary<string, double> GetRangeWithScoresFromSortedSetByLowestScore(string setId, string fromStringScore, string toStringScore)
		{
			return this.TryCatch<IDictionary<string, double>>(() => this.client.GetRangeWithScoresFromSortedSetByLowestScore(setId, fromStringScore, toStringScore), setId);
		}

		public IDictionary<string, double> GetRangeWithScoresFromSortedSetByLowestScore(string setId, double fromScore, double toScore, int? skip, int? take)
		{
			return this.TryCatch<IDictionary<string, double>>(() => this.client.GetRangeWithScoresFromSortedSetByLowestScore(setId, fromScore, toScore, skip, take), setId);
		}

		public IDictionary<string, double> GetRangeWithScoresFromSortedSetByLowestScore(string setId, long fromScore, long toScore, int? skip, int? take)
		{
			return this.TryCatch<IDictionary<string, double>>(() => this.client.GetRangeWithScoresFromSortedSetByLowestScore(setId, fromScore, toScore, skip, take), setId);
		}

		public IDictionary<string, double> GetRangeWithScoresFromSortedSetByLowestScore(string setId, string fromStringScore, string toStringScore, int? skip, int? take)
		{
			return this.TryCatch<IDictionary<string, double>>(() => this.client.GetRangeWithScoresFromSortedSetByLowestScore(setId, fromStringScore, toStringScore, skip, take), setId);
		}

		public IDictionary<string, double> GetRangeWithScoresFromSortedSetDesc(string setId, int fromRank, int toRank)
		{
			return this.TryCatch<IDictionary<string, double>>(() => this.client.GetRangeWithScoresFromSortedSetDesc(setId, fromRank, toRank), setId);
		}

		public long GetSetCount(string setId)
		{
			return this.TryCatch<long>(() => this.client.GetSetCount(setId), setId);
		}

		public List<string> GetSortedEntryValues(string key, int startingFrom, int endingAt)
		{
			return this.TryCatch<List<string>>(() => this.client.GetSortedEntryValues(key, startingFrom, endingAt), key);
		}

		public long GetSortedSetCount(string setId)
		{
			return this.TryCatch<long>(() => this.client.GetSortedSetCount(setId), setId);
		}

		public long GetSortedSetCount(string setId, double fromScore, double toScore)
		{
			return this.TryCatch<long>(() => this.client.GetSortedSetCount(setId, fromScore, toScore), setId);
		}

		public long GetSortedSetCount(string setId, long fromScore, long toScore)
		{
			return this.TryCatch<long>(() => this.client.GetSortedSetCount(setId, fromScore, toScore), setId);
		}

		public long GetSortedSetCount(string setId, string fromStringScore, string toStringScore)
		{
			return this.TryCatch<long>(() => this.client.GetSortedSetCount(setId, fromStringScore, toStringScore), setId);
		}

		public string GetSubstring(string key, int fromIndex, int toIndex)
		{
			return this.TryCatch<string>(delegate
			{
				byte[] bytes = ((RedisClient)this.client).GetRange(key, fromIndex, toIndex);
				if (bytes != null)
				{
					return StringExtensions.FromUtf8Bytes(bytes);
				}
				return null;
			}, key);
		}

		public TimeSpan GetTimeToLive(string key)
		{
			return this.TryCatch<TimeSpan>(delegate
			{
				TimeSpan? t = this.client.GetTimeToLive(key);
				if (!t.HasValue)
				{
					return TimeSpan.Zero;
				}
				return t.Value;
			}, key);
		}

		public HashSet<string> GetUnionFromSets(params string[] setIds)
		{
			return this.TryCatch<HashSet<string>>(() => this.client.GetUnionFromSets(setIds), setIds[0]);
		}

		public string GetValue(string key)
		{
			return this.TryCatch<string>(() => this.client.GetValue(key), key);
		}

		public string GetValueFromHash(string hashId, string key)
		{
			return this.TryCatch<string>(() => this.client.GetValueFromHash(hashId, key), hashId);
		}

		public List<string> GetValues(List<string> keys)
		{
			return this.TryCatch<List<string>>(() => this.client.GetValues(keys), keys[0]);
		}

		public List<T> GetValues<T>(List<string> keys)
		{
			return this.TryCatch<List<T>>(() => this.client.GetValues<T>(keys), keys[0]);
		}

		public List<string> GetValuesFromHash(string hashId, params string[] keys)
		{
			return this.TryCatch<List<string>>(() => this.client.GetValuesFromHash(hashId, keys), hashId);
		}

		public Dictionary<string, T> GetValuesMap<T>(List<string> keys)
		{
			return this.TryCatch<Dictionary<string, T>>(() => this.client.GetValuesMap<T>(keys), keys[0]);
		}

		public Dictionary<string, string> GetValuesMap(List<string> keys)
		{
			return this.TryCatch<Dictionary<string, string>>(() => this.client.GetValuesMap(keys), keys[0]);
		}

		public bool HashContainsEntry(string hashId, string key)
		{
			return this.TryCatch<bool>(() => this.client.HashContainsEntry(hashId, key), hashId);
		}

		public double IncrementItemInSortedSet(string setId, string value, double incrementBy)
		{
			return this.TryCatch<double>(() => this.client.IncrementItemInSortedSet(setId, value, incrementBy), setId);
		}

		public double IncrementItemInSortedSet(string setId, string value, long incrementBy)
		{
			return this.TryCatch<double>(() => this.client.IncrementItemInSortedSet(setId, value, incrementBy), setId);
		}

		public long IncrementValue(string key)
		{
			return this.TryCatch<long>(() => this.client.IncrementValue(key), key);
		}

		public long IncrementValueBy(string key, int count)
		{
			return this.TryCatch<long>(() => this.client.IncrementValueBy(key, count), key);
		}

		public long IncrementValueInHash(string hashId, string key, int incrementBy)
		{
			return this.TryCatch<long>(() => this.client.IncrementValueInHash(hashId, key, incrementBy), hashId);
		}

		public void MoveBetweenSets(string fromSetId, string toSetId, string item)
		{
			this.TryCatch(delegate
			{
				this.client.MoveBetweenSets(fromSetId, toSetId, item);
			}, fromSetId);
		}

		public string PopAndPushItemBetweenLists(string fromListId, string toListId)
		{
			return this.TryCatch<string>(() => this.client.PopAndPushItemBetweenLists(fromListId, toListId), fromListId);
		}

		public string PopItemFromList(string listId)
		{
			return this.TryCatch<string>(() => this.client.PopItemFromList(listId), listId);
		}

		public string PopItemFromSet(string setId)
		{
			return this.TryCatch<string>(() => this.client.PopItemFromSet(setId), setId);
		}

		public string PopItemWithHighestScoreFromSortedSet(string setId)
		{
			return this.TryCatch<string>(() => this.client.PopItemWithHighestScoreFromSortedSet(setId), setId);
		}

		public string PopItemWithLowestScoreFromSortedSet(string setId)
		{
			return this.TryCatch<string>(() => this.client.PopItemWithLowestScoreFromSortedSet(setId), setId);
		}

		public void PrependItemToList(string listId, string value)
		{
			this.TryCatch(delegate
			{
				this.client.PrependItemToList(listId, value);
			}, listId);
		}

		public void PrependRangeToList(string listId, List<string> values)
		{
			this.TryCatch(delegate
			{
				this.client.PrependRangeToList(listId, values);
			}, listId);
		}

		public long PublishMessage(string toChannel, string message)
		{
			return this.TryCatch<long>(() => this.client.PublishMessage(toChannel, message), string.Empty);
		}

		public void PushItemToList(string listId, string value)
		{
			this.TryCatch(delegate
			{
				this.client.PushItemToList(listId, value);
			}, listId);
		}

		public void RemoveAllFromList(string listId)
		{
			this.TryCatch(delegate
			{
				this.client.Remove(listId);
			}, listId);
		}

		public string RemoveEndFromList(string listId)
		{
			return this.TryCatch<string>(() => this.client.RemoveEndFromList(listId), listId);
		}

		public bool RemoveEntry(params string[] args)
		{
			return this.TryCatch<bool>(() => this.client.RemoveEntry(args), args[0]);
		}

		public bool RemoveEntryFromHash(string hashId, string key)
		{
			return this.TryCatch<bool>(() => this.client.RemoveEntryFromHash(hashId, key), hashId);
		}

		public long RemoveItemFromList(string listId, string value)
		{
			return this.TryCatch<long>(() => this.client.RemoveItemFromList(listId, value), listId);
		}

		public long RemoveItemFromList(string listId, string value, int noOfMatches)
		{
			return this.TryCatch<long>(() => this.client.RemoveItemFromList(listId, value, noOfMatches), listId);
		}

		public void RemoveItemFromSet(string setId, string item)
		{
			this.TryCatch(delegate
			{
				this.client.RemoveItemFromSet(setId, item);
			}, setId);
		}

		public bool RemoveItemFromSortedSet(string setId, string value)
		{
			return this.TryCatch<bool>(() => this.client.RemoveItemFromSortedSet(setId, value), setId);
		}
		/// <summary>
		///  骚操作-- redis 连接池-- 如果出现高并发,客户端的连接数量会上限,为了节省资源,重复利用连接对象,通过线程池去获取连接
		/// </summary>
		/// <param name="host"></param>
		/// <param name="port"></param>
		/// <param name="db"></param>
		/// <returns></returns>
		public static IRedisClientsManager GetPoolClient(string host, int port, int db)
		{
			return new PooledRedisClientManager(db, host + ":" + port);
		}
		public long RemoveRangeFromSortedSet(string setId, int minRank, int maxRank)
		{
			return this.TryCatch<long>(() => this.client.RemoveRangeFromSortedSet(setId, minRank, maxRank), setId);
		}

		public long RemoveRangeFromSortedSetByScore(string setId, double fromScore, double toScore)
		{
			return this.TryCatch<long>(() => this.client.RemoveRangeFromSortedSetByScore(setId, fromScore, toScore), setId);
		}

		public long RemoveRangeFromSortedSetByScore(string setId, long fromScore, long toScore)
		{
			return this.TryCatch<long>(() => this.client.RemoveRangeFromSortedSetByScore(setId, fromScore, toScore), setId);
		}

		public string RemoveStartFromList(string listId)
		{
			return this.TryCatch<string>(() => this.client.RemoveStartFromList(listId), listId);
		}

		public void RenameKey(string fromName, string toName)
		{
			this.TryCatch(delegate
			{
				this.client.RenameKey(fromName, toName);
			}, string.Empty);
		}

		public List<string> SearchKeys(string pattern)
		{
			return this.TryCatch<List<string>>(() => this.client.SearchKeys(pattern), pattern);
		}

		public void SetAll(Dictionary<string, string> map)
		{
			this.TryCatch(delegate
			{
				this.client.SetAll(map);
			}, string.Empty);
		}

		public void SetAll(IEnumerable<string> keys, IEnumerable<string> values)
		{
			this.TryCatch(delegate
			{
				this.client.SetAll(keys, values);
			}, string.Empty);
		}

		public bool SetContainsItem(string setId, string item)
		{
			return this.TryCatch<bool>(() => this.client.SetContainsItem(setId, item), setId);
		}

		public void SetEntry(string key, string value)
		{
			this.TryCatch(delegate
			{
				this.client.SetValue(key, value);
			}, key);
		}

		public void SetEntry(string key, string value, TimeSpan expireIn)
		{
			this.TryCatch(delegate
			{
				this.client.SetValue(key, value, expireIn);
			}, key);
		}

		public bool SetEntryIfNotExists(string key, string value)
		{
			return this.TryCatch<bool>(() => this.client.SetValueIfNotExists(key, value), key);
		}

		public bool SetEntryInHash(string hashId, string key, string value)
		{
			return this.TryCatch<bool>(() => this.client.SetEntryInHash(hashId, key, value), hashId);
		}

		public bool SetEntryInHashIfNotExists(string hashId, string key, string value)
		{
			return this.TryCatch<bool>(() => this.client.SetEntryInHashIfNotExists(hashId, key, value), hashId);
		}

		public void SetItemInList(string listId, int listIndex, string value)
		{
			this.TryCatch(delegate
			{
				this.client.SetItemInList(listId, listIndex, value);
			}, listId);
		}

		public void SetRangeInHash(string hashId, IEnumerable<KeyValuePair<string, string>> keyValuePairs)
		{
			this.TryCatch(delegate
			{
				this.client.SetRangeInHash(hashId, keyValuePairs);
			}, hashId);
		}

		public bool SortedSetContainsItem(string setId, string value)
		{
			return this.TryCatch<bool>(() => this.client.SortedSetContainsItem(setId, value), setId);
		}

		public void StoreAsHash<T>(T entity)
		{
			this.TryCatch(delegate
			{
				this.client.StoreAsHash<T>(entity);
			}, string.Empty);
		}


		public bool SetEntryInHash<T>(string hashId, string key, T value)
		{
			return this.TryCatch<bool>(() => this.client.SetEntryInHash(hashId, key, TextExtensions.SerializeToString<T>(value)), hashId);
		}

		public T GetValueFromHash<T>(string hashId, string key)
		{
			return this.TryCatch<T>(() => JsonSerializer.DeserializeFromString<T>(this.client.GetValueFromHash(hashId, key)), hashId);
		}

		public bool SetEntryInHashIfNotExists<T>(string hashId, string key, T value)
		{
			return this.TryCatch<bool>(() => this.client.SetEntryInHashIfNotExists(hashId, key, TextExtensions.SerializeToString<T>(value)), hashId);
		}

		public IDisposable AcquireLock(string key)
		{
			return this.TryCatch<IDisposable>(() => this.client.AcquireLock(key), key);
		}

		public IDisposable AcquireLock(string key, TimeSpan timeOut)
		{
			return this.TryCatch<IDisposable>(() => this.client.AcquireLock(key, timeOut), key);
		}


		public DateTime GetServerTime()
		{
			return this.TryCatch<DateTime>(() => this.client.GetServerTime(), string.Empty);
		}


	}
}
