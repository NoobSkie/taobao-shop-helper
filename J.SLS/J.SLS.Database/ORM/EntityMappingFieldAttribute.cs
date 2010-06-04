using System;

namespace J.SLS.Database.ORM
{
    /// <summary>
    /// ʵ��������־û��ֶεı�ע��
    /// �������ø��ֶ�ӳ����ֶε���Ϣ������ӳ����ֶ�������Ϊnull��մ���
    /// ֻ�ܽ������Զ��嵽��������ϡ�
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EntityMappingFieldAttribute : Attribute
    {
        /// <summary>
        /// ӳ�䵽���ݿ���ֶ���������Ϊnull��մ�
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// �Ƿ���Ҫ���µ����ݿ��У�Ĭ��Ϊtrue
        /// </summary>
        public bool NeedUpdate { get; set; }
        /// <summary>
        /// �Ƿ�Ϊ�Զ����ɵ��ֶΣ����Ϊtrue������ʱ���Դ��ֶΡ�Ĭ��Ϊfalse
        /// </summary>
        public bool IsAutoField { get; set; }
        /// <summary>
        /// �Ƿ�Ϊ���ݿ��е�������Ĭ��Ϊfalse
        /// </summary>
        public bool IsKey { get; set; }

        /// <summary>
        /// ��ʼ������ʵ���������ֶ�ӳ������,�ֶ�������Ϊnull��մ�
        /// Ĭ�ϸ��ֶβ�Ϊ������������Ҫ����
        /// </summary>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// ����������������쳣��
        /// 1.�����fieldNameΪnull��մ�ʱ
        /// </exception>
        /// <param name="fieldName">ӳ�䵽���ݿ��е��ֶ���</param>
        public EntityMappingFieldAttribute(string fieldName)
        {
            this.FieldName = fieldName;
            this.IsKey = false;
            this.NeedUpdate = true;
        }
    }
}