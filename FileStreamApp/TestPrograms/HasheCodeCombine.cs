using FileStreamApp;

namespace TestApp.TestPrograms;

public class HasheCodeCombine : ITestProgram
{
    public void Run()
    {
        var docInfo = new DocInfo
            { DocUniqId = new Guid("757982dc-638f-4973-b763-13486d5a0c7e"), DocNodeId = new DocNodeId(1, 2) };
        var docInfo2 = new DocInfo
            { DocUniqId = new Guid("757982dc-638f-4973-b763-13486d5a0c7e"), DocNodeId = new DocNodeId(1, 2) };
        Console.WriteLine($"{docInfo.GetHashCode()} : {docInfo2.GetHashCode()}");
        Console.WriteLine(string.Join(", ", new[] { docInfo, docInfo2 }.Distinct()));
    }

    public class DocNodeId
    {
        public DocNodeId(int nodeId, int docId)
        {
            DocId = docId;
            NodeId = nodeId;
        }

        public int DocId { get; }

        public int NodeId { get; }

        public override string ToString()
        {
            return $"{NodeId}.{DocId}";
        }
    }

    public class DocInfo : IEqualityComparer<DocInfo>
    {
        /// <summary>
        ///     Идентификатор документа.
        /// </summary>
        public Guid DocUniqId { get; set; }

        /// <summary>
        ///     DocNodeId загруженного документа.
        /// </summary>
        public DocNodeId DocNodeId { get; set; }

        /// <inheritdoc />
        public bool Equals(DocInfo x, DocInfo y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (ReferenceEquals(x, null))
                return false;
            if (ReferenceEquals(y, null))
                return false;

            return x.DocUniqId.Equals(y.DocUniqId)
                   && x.DocNodeId.NodeId.Equals(y.DocNodeId.NodeId)
                   && x.DocNodeId.DocId.Equals(y.DocNodeId.DocId);
        }

        /// <inheritdoc />
        public int GetHashCode(DocInfo obj)
        {
            return HashCode.Combine(obj.DocUniqId, obj.DocNodeId.DocId, obj.DocNodeId.NodeId);
        }

        /// <inheritdoc />
        //public bool Equals(DocInfo y)
        //{
        //    if (ReferenceEquals(this, y))
        //        return true;
        //    if (ReferenceEquals(this, null))
        //        return false;
        //    if (ReferenceEquals(this, null))
        //        return false;

        //    return this.DocUniqId.Equals(y.DocUniqId)
        //           && DocNodeId.NodeId.Equals(y.DocNodeId.NodeId)
        //           && DocNodeId.DocId.Equals(y.DocNodeId.DocId);
        //}

        ///// <inheritdoc/>
        //public override int GetHashCode()
        //{
        //    //var r = new Random();
        //    //return r.Next();
        //    return HashCode.Combine(DocUniqId, DocNodeId.DocId, DocNodeId.NodeId);
        //}
        public override string ToString()
        {
            return $"{DocUniqId}:{DocNodeId}";
        }
    }
}